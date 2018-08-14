using HM.Common_;
using HM.DTO;
using HM.DTO.FacePlatform;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.Face.Common_;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HM.Utils_;

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
            bool isSection = true;
            int pageNumber = 1, rowsPerPage = 50, totalPage = 0;
            DateTime fromDate = GetMinDateTime();
            DateTime toDate = DateTime.Now;

            while (true)
            {
                //1、获取需要同步人脸信息的小区用户（子对象包括需要同步的人脸数据）
                PagerData<User> pagerData = _userBLL.GetUserForPushToDevice(pageNumber - 1, rowsPerPage, fromDate, toDate);
                if (pagerData == null || pagerData.rows == null || pagerData.rows.Count < 0)
                {
                    jobFrom.ShowMessage(showName + "没有需要同步的数据", MessageType.Information);
                    return;
                }
                else
                {
                    //
                    IList<Mao> lstMao = _maoBLL.Get();
                    Dictionary<int, Face.Common_.Face> dicMao = new Dictionary<int, Face.Common_.Face>();
                    foreach (var mao in lstMao)
                    {
                        Face.Common_.Face face = FaceFactory.CreateFace(mao.ip, mao.port.ToInt_() ?? 8080, FaceVender.EyeCool);
                        dicMao.Add(mao.id, face); ;
                    }

                    jobFrom.ShowMessage(string.Format(showName + "开始同步数据到<{0}>，同步成功前请不要退出本系统", _mao.mao_name), MessageType.Information);

                    IEnumerable<User> user_registers = pagerData.rows;
                    //2、遍历用户
                    foreach (var user in user_registers)
                    {
                        if (user.Registers == null && !user.Registers.Any())
                        {
                            continue;
                        }
                        else
                        {
                            //2.1、获取用户的可用人脸信息
                            IEnumerable<Mao> lstUserMao;
                            if (isSection)
                            {
                                lstUserMao = lstMao.Where(it => it.MaoBuildings.Any(mb => user.UserHouses.Any(uh => uh.House.building_code == mb.building_code)));
                            }
                            else
                            {
                                lstUserMao = lstMao;
                            }
                            //2.2、遍历人脸信息
                            foreach (var register in user.Registers)
                            {
                                //2.2.1、根据用户->房屋->楼栋->关联的人脸一体机

                                //2.2.2、并行注册
                                Parallel.ForEach(lstMao, mao =>
                                {
                                    if (dicMao.ContainsKey(mao.id))
                                    {
                                        var face = dicMao[mao.id];
                                        if (face.VisualTelnet(mao.ip, mao.port.ToInt_() ?? 8080))
                                        {
                                            ActionResult arChecking = face.Checking(register.face_id,
                                                RegisterType.手动注册,
                                                register.photo_path,
                                                "同步");
                                            if (arChecking.IsSuccess)
                                            {
                                                ActionResult arRegister = face.Register(new RegisterInput()
                                                {
                                                    activeTime = user.end_time,
                                                    Birthday = user.birthday,
                                                    CertificateType = Face.Common_.EyeCool.CertificateType.唯一标识,
                                                    cNO = mao.mao_no,
                                                    CRMId = user.user_uid,
                                                    FaceId = "",
                                                    Name = user.name,
                                                    PeopleId = user.people_id,
                                                    Phone = user.mobile,
                                                    ProjectCode = "",
                                                    RegisterType = register.register_type,
                                                    RoomNo = "",
                                                    Sex = user.sex,
                                                    UserType = user.UserHouses.ToList()?[0].relation
                                                });
                                                if (!arRegister.IsSuccess)
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
                                            else
                                            {
                                                LogHelper.Error(arChecking.ToAlertString());
                                            }
                                        }
                                        else
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
                                });
                            }
                        }
                    }

                    pageNumber++;
                    if (pageNumber > totalPage)
                    {
                        jobFrom.ShowMessage("本次任务执行完毕！", MessageType.Information);
                        break;
                    }
                }
            }

            //_mao.last_pull_date = toDate;//防止同步过程中有数据写入，暂不更新last_pull_date
            //_mao.is_init = 1;
            //_maoBLL.Update(_mao);//同步结束，更新猫初始化状态

            jobFrom.ShowMessage(string.Format("##" + showName + "同步数据到<{0}>成功", _mao.mao_name), MessageType.Information);
        }
    }
}
