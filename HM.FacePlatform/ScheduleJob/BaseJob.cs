using HM.DTO;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.Face.Common_;
using HM.FacePlatform.BLL;
using HM.FacePlatform.Model;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HM.FacePlatform
{
    public abstract class BaseJob
    {
        public static ScheduleJob _JobFrom;

        public string _ProjectCode;
        public string _PropertyHouseCode;
        public string _VirtualHouseCode;
        public string _PictureDirectory;
        public int _MaxRetryTime;


        public string _showName { get; set; } = "【同步】";

        protected MaoBLL _maoBLL;
        protected MaoBuildingBLL _maoBuildingBLL;
        protected UserBLL _userBLL;
        protected RegisterBLL _registerBLL;
        protected MaoFailedJobBLL _maoFailedJobBLL;
        protected ActionLogBLL _actionLogBLL;

        protected BaseJob()
        {
            _maoBLL = new MaoBLL();
            _maoBuildingBLL = new MaoBuildingBLL();
            _userBLL = new UserBLL();
            _registerBLL = new RegisterBLL();
            _maoFailedJobBLL = new MaoFailedJobBLL();
            _actionLogBLL = new ActionLogBLL();

            if (Program._Mainform != null)
            {
                _ProjectCode = Program._Mainform._ProjectCode;
                _PropertyHouseCode = Program._Mainform._PropertyHouseCode;
                _VirtualHouseCode = Program._Mainform._VirtualHouseCode;
                _PictureDirectory = FacePlatformCache.GetPictureDirectory();
                _MaxRetryTime = FacePlatformCache.GetMaxRetryTime();
            }
            else
            {
                throw new Exception("计划任务需要在主窗口中创建！");
            }
        }

        protected DateTime GetMinDateTime()
        {
            return Convert.ToDateTime("2000-01-01");
        }

        protected ActionResult Register(User user, Register register, Face.Common_.Face face, Mao _mao, bool isAddToMaoFailedJob = true)
        {
            ActionResult actionResult = new ActionResult();
            string fileName = Path.Combine(_PictureDirectory, register.photo_path);
            if (!File.Exists(fileName))
            {
                actionResult.Add($"找不到用户【{user.name}】的人脸图片【{fileName}】");
                return actionResult;
            }

            var arChecking = face.Checking(register.face_id,
                                   RegisterType.手动注册,//客户端同步默认为手动注册
                                   Image_.ImageToBase64(fileName),
                                   _showName);
            if (arChecking.IsSuccess)
            {
                _JobFrom.ShowMessage($"{ _showName }用户【{ user.name }】的人脸图片校验成功【register.id:{ register.id }】同步成功！", MessageType.Success);

                ActionResult arRegister = face.Register(new RegisterInput()
                {
                    ActiveTime = user.end_time,
                    Birthday = user.birthday,
                    CertificateType = Face.Common_.EyeCool.CertificateType.唯一标识,
                    MaoNO = _mao.mao_no,
                    UserUid = user.user_uid,
                    FaceId = register.face_id,
                    Name = user.name,
                    PeopleId = user.people_id,
                    Phone = user.mobile,
                    ProjectCode = _ProjectCode,
                    RegisterType = register.register_type,
                    RoomNo = "",
                    Sex = user.sex,
                    UserType = _userBLL.GetUserType(user.user_uid),
                    IsNeedAudit = register.check_state != CheckType.审核通过
                });
                if (arRegister.IsSuccess)
                {
                    //因是初始化动作，无需变更user的时间
                    _JobFrom.ShowMessage($"{ _showName }用户【{ user.name }】的人脸注册信息【register.id:{register.id}】同步成功！", MessageType.Success);
                    //添加操作记录
                    _actionLogBLL.Add(new ActionLog
                    {
                        table_id = register.id,
                        action_type = ActionType.平台注册,
                        action = ActionName.新增,
                        action_by = Program._Account.id,
                        remark = _showName,
                    });
                }
                else
                {
                    actionResult.Add(arRegister);
                    if (!arRegister.Any("此照片已绑定"))
                    {
                        if (isAddToMaoFailedJob)
                        {
                            MaoFailedJob job = new MaoFailedJob
                            {
                                register_or_user_id = register.id,
                                mao_id = _mao.id,
                                job_type = JobType.注册,
                            };
                            _maoFailedJobBLL.AddOrUpdate(it => new
                            {
                                it.register_or_user_id,
                                it.mao_id,
                                it.job_type
                            }, job);
                        }
                    }
                    _JobFrom.ShowMessage($"{ _showName }用户【{ user.name }】的人脸图片【register.id:{register.id}】校验失败：{ arRegister.ToAlertString() }", MessageType.Error);
                }
            }
            else
            {
                actionResult.Add(arChecking);
                _JobFrom.ShowMessage($"{ _showName }人脸图片检查不通过：{arChecking.ToAlertString()}", MessageType.Error);
                if (isAddToMaoFailedJob)
                {
                    _maoFailedJobBLL.AddOrUpdate(it => new
                    {
                        it.register_or_user_id,
                        it.mao_id,
                        it.job_type
                    }, new MaoFailedJob
                    {
                        register_or_user_id = register.id,
                        mao_id = _mao.id,
                        job_type = JobType.注册,
                    });
                }
            }
            return actionResult;
        }

        protected void Delete(List<Mao> maos, User user, Register register, HMFaceObj faceObj, Mao excluedMao)
        {
            //都是删除状态，无需处理
            if (register.is_del == IsDelType.是) return;

            _JobFrom.ShowMessage($"{_showName}人脸一体机【{excluedMao.mao_name}】上检测到用户【{user.name}】的照片【{register.photo_path}】已被删除！", MessageType.Information);

            register.is_del = IsDelType.是;
            register.change_time = DateTime.Now;
            _registerBLL.Edit(register);//更新数据库
            string filePath = Path.Combine(_PictureDirectory, register.photo_path);
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    _JobFrom.ShowMessage($"{_showName}从人脸综合管理平台删除照片【{filePath}】失败：{Exception_.GetInnerException(ex).Message}！", MessageType.Error);
                }
            }

            _JobFrom.ShowMessage($"{_showName}从人脸综合管理平台删除照片【{filePath}】成功", MessageType.Success);

            IEnumerable<Mao> lstMao = null;
            bool isFaceSection = Config_.GetBool("IsFaceSection") ?? false;
            if (isFaceSection)
            {
                lstMao = _maoBLL.GetForFaceSection(user.user_uid).Where(it => it.id != excluedMao.id);
            }
            else
            {
                lstMao = maos.Where(it => it.id != excluedMao.id);
            }

            Parallel.ForEach(lstMao, new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 }, (itemMao) =>
            {
                if (itemMao.id == excluedMao.id) return;
                string ip = itemMao.GetIP();
                int port = itemMao.GetPort();
                var itemFace = FaceFactory.CreateFace(ip, port, FaceVender.EyeCool);
                Delete(user, register, itemMao, itemFace);
            });
        }

        protected void Delete(User user, Register register, Mao itemMao, Face.Common_.Face itemFace)
        {
            ActionResult result = itemFace.FaceDel(user.people_id, register.face_id);
            if (result.IsSuccess)
            {
                _JobFrom.ShowMessage($"{ _showName } 从人脸一体机【{ itemMao.mao_name }】上删除人脸注册信息【{ register.face_id }】成功", MessageType.Success);
            }
            else
            {
                _maoFailedJobBLL.AddOrUpdate(it => new
                {
                    it.register_or_user_id,
                    it.mao_id,
                    it.job_type
                }, new MaoFailedJob
                {
                    register_or_user_id = register.id,
                    mao_id = itemMao.id,
                    job_type = JobType.注册,
                });

                _JobFrom.ShowMessage($"{ _showName } 从人脸一体机【{ itemMao.mao_name }】上删除人脸注册信息【{ register.face_id }】失败(稍后将自动重试)：{result.ToAlertString()}", MessageType.Error);
            }
        }
    }
}
