using HM.DTO;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.Face.Common_;
using HM.FacePlatform.Model;
using HM.Utils_;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HM.FacePlatform
{
    /// <summary>
    /// 新增猫同步数据使用，不加入到定时任务，每猫仅可运行一次
    /// </summary>
    public class InitJob : BaseJob
    {
        Mao _mao;
        readonly string showName = "[初始化]";
        public InitJob(Mao _mao)
        {
            this._mao = _mao;
        }

        public void Execute()
        {
            Init();
        }

        private void Init()
        {
            string ip = _mao.GetIP();
            int port = _mao.GetPort();
            Face.Common_.Face face = FaceFactory.CreateFace(ip, port, FaceVender.EyeCool);
            bool isOk = NetWork_.VisualTelnet(ip, port);
            if (!isOk)
            {
                _JobFrom.ShowMessage($"人脸一体机【{_mao.mao_name}】IP【{_mao.ip}】端口【{_mao.port}】网络异常，初始化失败！", MessageType.Information);
                return;
            }
            bool isFaceSection = Config_.GetBool("IsFaceSection") ?? false;
            if (isFaceSection)
            {
                _JobFrom.ShowMessage($"系统已启用分区块功能，请确认已人脸一体机已关联楼栋！", MessageType.Information);
            }
            int pageIndex = 0, pageSize = 50, totalPage = 0;
            DateTime fromDate = GetMinDateTime();
            DateTime toDate = DateTime.Now;
            bool returnTotal = true;
            while (true)
            {
                PagerData<User> pagerData = null;
                try
                {
                    if (isFaceSection)
                    {
                        pagerData = _userBLL.GetUserWithRegisterForPushToDevice(_mao.id, pageIndex, pageSize, fromDate, toDate, returnTotal);
                    }
                    else
                    {
                        pagerData = _userBLL.GetUserWithRegisterForPushToDevice(null, pageIndex, pageSize, fromDate, toDate, returnTotal);
                    }
                }
                catch (Exception ex)
                {
                    _JobFrom.ShowMessage($"数据查询失败：{ Exception_.GetInnerException(ex).Message }", MessageType.Error);
                    return;
                }

                try
                {
                    if (pagerData == null || pagerData.rows == null || pagerData.rows.Count <= 0)
                    {
                        if (true)
                        {
                            _JobFrom.ShowMessage(showName + "没有需要同步的数据", MessageType.Information);
                        }
                        return;
                    }
                    else
                    {
                        _JobFrom.ShowMessage($"{ showName }开始同步数据到【{_mao.mao_name}】，同步成功前请不要退出本系统", MessageType.Information);

                        List<User> userWithRegisters = pagerData.rows;
                        //2、遍历用户
                        foreach (var user in userWithRegisters)
                        {
                            if (user.registers == null && !user.registers.Any()) continue;

                            //2.1、遍历人脸信息
                            foreach (var register in user.registers)
                            {
                                //2.2.1、根据用户->房屋->楼栋->关联的人脸一体机
                                string fileName = Path.Combine(_PictureDirectory, register.photo_path);
                                if (!File.Exists(fileName))
                                {
                                    _JobFrom.ShowMessage($"{ showName }找不到用户【{user.name}】的图片【{fileName}】，register.id【{ register.id }】", MessageType.Error);
                                    return;
                                }
                                ActionResult arChecking = face.Checking(register.face_id,
                                    RegisterType.手动注册,//客户端同步默认为手动注册
                                    Image_.ImageToBase64(fileName),
                                    showName);
                                if (arChecking.IsSuccess)
                                {
                                    _JobFrom.ShowMessage($"{ showName }用户【{ user.name }】的人脸图片校验成功【register.id:{register.id}】同步成功！", MessageType.Success);

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
                                        _JobFrom.ShowMessage($"用户【{ user.name }】的人脸注册信息【register.id:{register.id}】同步成功！", MessageType.Success);
                                        //添加操作记录
                                        _actionLogBLL.Add(new ActionLog
                                        {
                                            table_id = register.id,
                                            action_type = ActionType.平台注册,
                                            action = ActionName.新增,
                                            action_by = Program._Account.id,
                                            remark = showName,
                                        });
                                    }
                                    else
                                    {
                                        if (!arRegister.Any("此照片已绑定"))
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
                                        _JobFrom.ShowMessage($"用户【{ user.name }】的人脸注册信息【register.id:{register.id}】注册失败：{ arRegister.ToAlertString() }", MessageType.Error);
                                    }
                                }
                                else
                                {
                                    _JobFrom.ShowMessage($"{ showName }人脸图片检查不通过：{arChecking.ToAlertString()}", MessageType.Error);
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
                        }
                    }

                    pageIndex++;
                    returnTotal = false;
                    if (pageIndex >= totalPage)
                    {
                        _JobFrom.ShowMessage($"{ showName }本次任务执行完毕！", MessageType.Information);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    _JobFrom.ShowMessage($"{ showName }同步异常：{ Exception_.GetInnerException(ex).Message }", MessageType.Error);
                }
            }

            _JobFrom.ShowMessage($"{ showName }本次同步数据到人脸一体机【{_mao.mao_name}】>完成！", MessageType.Information);
        }
    }
}
