using HM.Common_;
using HM.DTO;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HM.FacePlatform
{
    /// <summary>
    /// 此处处理在平台操作某猫任务失败的情况
    /// 1. 注册某张图片
    /// 2. 删除某张图片
    /// 3. 更新某用户审核状态
    /// 4. 更新过期时间
    /// </summary>
    [DisallowConcurrentExecution]
    public class PushJob : BaseJob, IJob
    {
        readonly string showName = "[修正]";
        public void Execute(IJobExecutionContext context)
        {
            if (!BLL.FacePlatformCache.GetALL<Mao>().Any())
            {
                _JobFrom.ShowMessage("还没有配置猫，请在[基础数据]添加配置", MessageType.Warning);
                return;
            }

            //ExecutePush();
        }

        private void ExecutePush()
        {
            IList<MaoFailedJob> jobs = _maoFailedJobBLL.Get();

            if (!jobs.Any()) return;

            foreach (MaoFailedJob job in jobs)
            {
                if (job.retry_time >= _MaxRetryTime) continue;

                Mao _taskMao = new Mao();
                var maos = BLL.FacePlatformCache.GetALL<Mao>();
                foreach (Mao _mao in maos)
                {
                    if (_mao.id == job.mao_id)
                    {
                        _taskMao = _mao;
                        break;
                    }
                }

                if (_taskMao.id == 0) continue;

                job.last_retry_date = DateTime.Now;
                job.retry_time++;

                switch (job.job_type)
                {
                    case JobType.注册:
                        Register(job, _taskMao);
                        break;
                    case JobType.审核:
                        Check(job, _taskMao, CheckType.审核通过);
                        break;
                    case JobType.删除:
                        //Delete(job, _taskMao);
                        break;
                    case JobType.审核不通过:
                        Check(job, _taskMao, CheckType.审核不通过);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Check(MaoFailedJob job, Mao _mao, CheckType checkType)
        {
            ActionResult<List<Register>> result = _registerBLL.GetWithUser(job.register_or_user_id);
            if (!result.IsSuccess)
            {
                _JobFrom.ShowMessage(result.ToAlertString(), MessageType.Information);
            }
            else if (result.Obj == null || result.Obj.Any())
            {
                return;
            }
            else
            {
                foreach (var register in result.Obj)
                {
                    // jobFrom.ShowMessage(string.Format(showName + "第{0}次更新<{1}>上<{2}>的审核状态/过期时间", job.retry_time, _mao.mao_name, _user.name)
                    //, MessageType.Information);

                    // ActionResult result = _registerBLL.UpdateExpireDate(_user, _mao, _user.end_time, isFirstMao, 0);//更新过期时间
                    // if (result.IsSuccess)
                    // {
                    //     result = _registerBLL.Check(_user, _user.check_state, _user.check_note, 0, projectCode, _mao, isFirstMao);//更新审核状态
                    // }

                    // if (result.IsSuccess)
                    // {
                    //     job.is_del = IsDelType.是;
                    //     jobFrom.ShowMessage(string.Format("**" + showName + "审核状态/过期时间更新成功"), MessageType.Success);
                    // }
                    // else
                    // {
                    //     jobFrom.ShowMessage(string.Format("**" + showName + "审核状态/过期时间更新失败(稍后将自动重试)：{0}", result.ToAlertString()), MessageType.Error);
                    // }

                    // _maoFailedJobBLL.Update(job);
                }
            }
        }

        private void Register(MaoFailedJob job, Mao _mao)
        {
            //Register _register = _registerBLL.Get(job.register_or_user_id);

            //if (_register == null) return;

            //UserRegisterDto user_register = _registerBLL.GetUserRegisterByUid(_register.user_uid);

            //if (user_register.id < 1) return;

            //if (_register.is_del == IsDelType.是)
            //{
            //    jobFrom.ShowMessage(string.Format(showName + "第{0}次删除<{1}>上<{2}>的照片{3}"
            //        , job.retry_time, _mao.mao_name, user_register.name, _register.photo_path), MessageType.Information);

            //    ActionResult result = _registerBLL.DeleteRegistedPhoto(user_register.people_id, _register, "", _mao, isFirstMao, 0);
            //    if (result.IsSuccess)
            //    {
            //        job.is_del = IsDelType.是;
            //        jobFrom.ShowMessage(string.Format("**" + showName + "照片删除成功"), MessageType.Success);
            //    }
            //    else
            //    {
            //        jobFrom.ShowMessage(string.Format("**" + showName + "照片删除失败(稍后将自动重试)：{0}", result.ToAlertString()), MessageType.Error);
            //    }
            //}
            //else
            //{
            //    jobFrom.ShowMessage(string.Format(showName + "第{0}次注册<{1}>上<{2}>的照片{3}"
            //        , job.retry_time, _mao.mao_name, user_register.name, _register.photo_path), MessageType.Information);

            //    string fileName = Path.Combine(photoPath, _register.photo_path);
            //    ActionResult result = _registerBLL.Register(user_register
            //        , fileName, _register.face_id, user_register.end_time, (int)RegisterType.手动注册, projectCode
            //        , _mao, isFirstMao, _register.id, 0);
            //    if (result.IsSuccess)
            //    {
            //        job.is_del = IsDelType.是;
            //        jobFrom.ShowMessage(string.Format("**" + showName + "照片注册成功"), MessageType.Success);
            //    }
            //    else
            //    {
            //        jobFrom.ShowMessage(string.Format("**" + showName + "照片注册失败(稍后将自动重试)：{0}", result.ToAlertString()), MessageType.Error);
            //    }
            //}

            //_maoFailedJobBLL.Update(job);
        }
    }
}
