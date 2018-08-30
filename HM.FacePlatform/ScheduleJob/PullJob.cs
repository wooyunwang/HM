using HM.FacePlatform.BLL;
using HM.Common_;
using HM.FacePlatform.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.DTO;
using System.Linq;
using System.Threading.Tasks;
using HM.Utils_;
using HM.Face.Common_;

namespace HM.FacePlatform
{
    /// <summary>
    /// 此处处理的情况，均是先同步到平台，然后同步到其他猫
    /// 1. 某猫上新增照片
    /// 2. 某猫上某张或某几张照片被删除
    /// </summary>
    [DisallowConcurrentExecution]
    public class PullJob : BaseJob, IJob
    {
        HouseBLL _houseBLL;
        public PullJob()
        {
            _showName = "【同步-拉取】";
            _houseBLL = new HouseBLL();
        }

        List<Mao> _maos = null;
        public void Execute(IJobExecutionContext context)
        {
            Execute();
        }

        public void Execute()
        {
            _maos = _maoBLL.Get();
            if (_maos.Any())
            {
                ExecutePull();
            }
            else
            {
                _JobFrom.ShowMessage("还没有配置人脸一体机，请在[基础数据]添加配置", MessageType.Warning);
            }
        }
        public void ExecutePull()
        {
            List<Mao> lstGoodMao = new List<Mao>();
            Parallel.ForEach(_maos, mao =>
            {
                string ip = mao.GetIP();
                int port = mao.GetPort();
                bool isOk = NetWork_.VisualTelnet(ip, port);
                if (isOk)
                {
                    lstGoodMao.Add(mao);
                }
                else
                {
                    _JobFrom.ShowMessage($"人脸一体机【{mao.mao_name}】IP【{mao.ip}】端口【{mao.port}】连接失败！", MessageType.Warning);
                }
            });

            foreach (Mao goodMao in lstGoodMao)
            {
                string ip = goodMao.GetIP();
                int port = goodMao.GetPort();
                Face.Common_.Face face = FaceFactory.CreateFace(ip, port, FaceVender.EyeCool);

                DateTime lastPullDate = goodMao.last_pull_date ?? DateTime.MinValue;
                if (lastPullDate == DateTime.MinValue) lastPullDate = GetMinDateTime();
                else lastPullDate = lastPullDate.AddMinutes(-10);

                DateTime latestStartDate = DateTime.Now;

                int pageNumber = 1, pageSize = 50;
                while (true)
                {
                    var getResult = face.GetRegisterPage(new GetRegisterPageInput()
                    {
                        DataTypes = new List<RegisterDataType>() {
                                RegisterDataType.注册审核已通过数据,
                                RegisterDataType.注册待审核数据
                            },
                        Endtime = DateTime.Now,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        ProjectCode = Program._Mainform._ProjectCode,
                        UpdateTime = lastPullDate
                    });
                    if (!getResult.IsSuccess)
                    {
                        _JobFrom.ShowMessage($"{_showName}从人脸一体机【{goodMao.mao_name}】获取更新失败：{getResult.ToAlertString()}", MessageType.Error);
                        break;
                    }

                    var lstOuput = getResult.Obj;

                    pageNumber++;

                    if (!lstOuput.Any())
                    {
                        _JobFrom.ShowMessage($"{_showName}人脸一体机【{goodMao.mao_name}】已没有需要同步的数据", MessageType.Information);
                        _maoBLL.Edit(it => it.id == goodMao.id, it => new Mao()
                        {
                            last_pull_date = latestStartDate
                        });
                        _maos = _maoBLL.Get();
                        break;
                    }

                    foreach (GetRegisterPageOutput output in lstOuput)
                    {
                        User user = _userBLL.GetUserWithRegister(output.UserUid, output.HMFaceObj.Select(it => it.FaceId));
                        if (user == null)
                        {
                            if (output.CheckState == CheckType.审核不通过) return;

                            user = new User
                            {
                                user_uid = output.UserUid,
                                data_from = DataFromType.人脸一体机手动添加,
                                reg_time = output.RegisterTime,
                                end_time = output.ActiveTime ?? DateTime.MinValue,
                                check_state = output.CheckState ?? CheckType.审核不通过,
                                check_time = output.CheckTime ?? DateTime.MinValue,
                                check_note = output.CheckMessage ?? "",
                                people_id = output.PeopleId,
                                name = output.PeopleName,
                                sex = output.Sex,
                                mobile = output.Phone
                            };

                            string house_code = _VirtualHouseCode;
                            if (output.UserType == UserType.工作人员)
                            {
                                house_code = _PropertyHouseCode;
                            }
                            else
                            {
                                House house = _houseBLL.FirstOrDefault(it => it.house_code == house_code);
                                if (house == null) house = _houseBLL.FirstOrDefault(it => it.house_name == house_code);//旧版本使用的house_name,在此做兼容
                                if (house != null) house_code = house.house_code;
                                if (house == null)
                                {
                                    house = _houseBLL.FirstOrDefault(it => it.house_name.Contains(house_code));
                                }
                            }

                            UserHouse user_house = new UserHouse
                            {
                                user_uid = user.user_uid,
                                house_code = house_code,
                                user_type = output.UserType,
                            };
                            user.user_houses = new List<UserHouse>();
                            user.user_houses.Add(user_house);
                            var addUserResult = _userBLL.Add(user);
                            if (addUserResult.IsSuccess)
                            {
                                _JobFrom.ShowMessage($"{_showName}检测到有新增的用户【{user.name}】", MessageType.Success);
                                if (output.HMFaceObj != null && output.HMFaceObj.Any())
                                {
                                    foreach (HMFaceObj faceObj in output.HMFaceObj)
                                    {
                                        Add(user, faceObj, goodMao);
                                    }
                                }
                            }
                            else
                            {
                                _JobFrom.ShowMessage(addUserResult.ToAlertString()
                                    , MessageType.Error);
                            }
                        }
                        else
                        {
                            if (user.reg_time != output.RegisterTime
                                || user.end_time != output.ActiveTime
                                || user.check_state != output.CheckState
                                || user.check_time != output.CheckTime
                                || user.people_id != output.PeopleId)
                            {
                                user.reg_time = output.RegisterTime;
                                user.end_time = output.ActiveTime ?? GetMinDateTime();
                                user.check_state = output.CheckState ?? CheckType.审核不通过;
                                user.check_time = output.CheckTime ?? GetMinDateTime();
                                user.people_id = output.PeopleId;
                                _userBLL.Edit(user);// 更新用户信息
                                _JobFrom.ShowMessage($"{_showName}已从【{goodMao.mao_name}】上同步用户【{user.name}】的审核信息", MessageType.Success);
                            }

                            if (!output.HMFaceObj.Any())
                            {
                                continue;
                            }
                            else
                            {
                                foreach (HMFaceObj faceObj in output.HMFaceObj)
                                {
                                    var register = user.registers.FirstOrDefault(it => it.face_id == faceObj.FaceId);
                                    if (register == null)
                                    {
                                        //新增
                                        Add(user, faceObj, goodMao);// 猫上有新增的图片
                                    }
                                    else
                                    {
                                        switch (faceObj.FaceState)
                                        {
                                            case HMFaceState.删除的数据:
                                                Delete(_maos, user, register, faceObj, goodMao);
                                                break;
                                            case HMFaceState.正常使用:
                                            case HMFaceState.待审核或禁用数据:
                                                Edit(user, register, faceObj, goodMao);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 添加人脸
        /// </summary>
        /// <param name="user"></param>
        /// <param name="faceObj"></param>
        /// <param name="excluedMao"></param>
        private void Add(User user, HMFaceObj faceObj, Mao excluedMao)
        {
            var face = FaceFactory.CreateFace(excluedMao.GetIP(), excluedMao.GetPort(), FaceVender.EyeCool);
            Uri rootUri = face.GetRootUri();
            Uri sourcePath = new Uri(rootUri, faceObj.ImageUrl);
            string fileName = Path.GetFileName(faceObj.ImageUrl);
            if (_registerBLL.DownloadFaceFile(sourcePath, _PictureDirectory))
            {
                Register register = new Register
                {
                    user_uid = user.user_uid,
                    face_id = faceObj.FaceId,
                    photo_path = fileName,
                    register_type = faceObj.RegisterType,
                    check_state = user.check_state
                };
                var addResult = _registerBLL.Add(register);
                if (addResult.IsSuccess)
                {
                    _JobFrom.ShowMessage($"{_showName}人脸一体机【{excluedMao.mao_name}】上新注册了用户【{user.name}】的人脸注册信息，已同步至综合管理平台！", MessageType.Success);

                    IEnumerable<Mao> lstMao = null;
                    bool isFaceSection = Config_.GetBool("IsFaceSection") ?? false;
                    if (isFaceSection)
                    {
                        lstMao = _maoBLL.GetForFaceSection(user.user_uid).Where(it => it.id != excluedMao.id);
                    }
                    else
                    {
                        lstMao = _maos.Where(it => it.id != excluedMao.id);
                    }

                    fileName = Path.Combine(_PictureDirectory, fileName);

                    Parallel.ForEach(lstMao, new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 }, (itemMao) =>
                    {
                        if (itemMao.id == excluedMao.id) return;
                        string ip = itemMao.GetIP();
                        int port = itemMao.GetPort();
                        var itemFace = FaceFactory.CreateFace(ip, port, FaceVender.EyeCool);
                        if (itemFace.VisualTelnet(ip, port))
                        {
                            Register(user, register, itemFace, itemMao, fileName);
                        }
                        else
                        {
                            _JobFrom.ShowMessage($"{ _showName }人脸一体机【{itemMao.mao_name}】IP【{itemMao.ip}】端口【{itemMao.port}】连接失败！", MessageType.Warning);
                            _JobFrom.ShowMessage($"{ _showName }人脸注册信息同步到【{itemMao.mao_name}】失败(稍后将自动重试)", MessageType.Error);
                            MaoFailedJob job = new MaoFailedJob
                            {
                                register_or_user_id = register.id,
                                mao_id = itemMao.id,
                                job_type = JobType.注册,
                            };
                            _maoFailedJobBLL.AddOrUpdate(it => new
                            {
                                it.register_or_user_id,
                                it.mao_id,
                                it.job_type
                            }, job);
                        }
                    });
                }
                else
                {
                    _JobFrom.ShowMessage($"{_showName}人脸一体机【{excluedMao.mao_name}】上新注册了用户【{user.name}】的人脸注册信息，同步至综合管理平台失败：{addResult.ToAlertString()}", MessageType.Error);
                }
            }
        }
        /// <summary>
        /// 从设备上拉人脸信息的情况
        /// </summary>
        /// <param name="registed_data"></param>
        /// <param name="faceObj"></param>
        /// <param name="excluedMao"></param>
        private void Edit(User user, Register register, HMFaceObj faceObj, Mao excluedMao)
        {
            IEnumerable<Mao> lstMao = null;
            bool isFaceSection = Config_.GetBool("IsFaceSection") ?? false;
            if (isFaceSection)
            {
                lstMao = _maoBLL.GetForFaceSection(user.user_uid).Where(it => it.id != excluedMao.id);
            }
            else
            {
                lstMao = _maos.Where(it => it.id != excluedMao.id);
            }

            string fileName = Path.Combine(_PictureDirectory, register.photo_path);

            Parallel.ForEach(lstMao, new ParallelOptions { MaxDegreeOfParallelism = Config_.GetInt("MaxDegreeOfParallelism") ?? 2 }, (itemMao) =>
            {
                if (itemMao.id == excluedMao.id) return;
                string ip = itemMao.GetIP();
                int port = itemMao.GetPort();
                var itemFace = FaceFactory.CreateFace(ip, port, FaceVender.EyeCool);
                if (itemFace.VisualTelnet(ip, port))
                {
                    Register(user, register, itemFace, itemMao, fileName);
                }
                else
                {
                    _JobFrom.ShowMessage($"{ _showName }人脸一体机【{itemMao.mao_name}】IP【{itemMao.ip}】端口【{itemMao.port}】连接失败！", MessageType.Warning);
                    _JobFrom.ShowMessage($"{ _showName }人脸注册信息同步到【{itemMao.mao_name}】失败(稍后将自动重试)", MessageType.Error);
                    MaoFailedJob job = new MaoFailedJob
                    {
                        register_or_user_id = register.id,
                        mao_id = itemMao.id,
                        job_type = JobType.注册,
                    };
                    _maoFailedJobBLL.AddOrUpdate(it => new
                    {
                        it.register_or_user_id,
                        it.mao_id,
                        it.job_type
                    }, job);
                }
            });
        }
    }
}
