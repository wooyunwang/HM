using HM.Common_;
using HM.DTO;
using HM.Enum_;
using HM.Enum_.FacePlatform;
using HM.Face.Common_;
using HM.FacePlatform.Model;
using HM.Utils_;
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
        public PushJob()
        {
            _showName = "【同步-修正】";
        }
        public void Execute(IJobExecutionContext context)
        {
            Execute();
        }
        /// <summary>
        /// 人脸一体机 —— 重新执行的时候，要重新拉数据
        /// </summary>
        List<Mao> _maos = null;

        public void Execute()
        {
            _maos = _maoBLL.Get();
            if (_maos.Any())
            {
                ExecutePush();
            }
            else
            {
                _JobFrom.ShowMessage("还没有配置人脸一体机，请在[基础数据]添加配置", MessageType.Warning);
            }
            ExecutePush();
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

                switch (job.job_type)
                {
                    case JobType.注册:
                        Register(job, _taskMao);
                        break;
                    case JobType.审核:
                        Check(job, _taskMao);
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 自动修复一体机上人脸注册信息的状态
        /// </summary>
        /// <param name="job"></param>
        /// <param name="mao"></param>
        /// <param name="checkType"></param>
        private void Check(MaoFailedJob job, Mao mao)
        {
            var register = _registerBLL.FirstOrDefault(it => it.id == job.register_or_user_id);
            if (register == null)
            {
                job.is_del = IsDelType.是;
                job.last_retry_date = DateTime.Now;
                job.retry_time++;
                job.retry_message = $"数据异常，找不到人脸注册信息【register.id:{job.register_or_user_id}】";
                _JobFrom.ShowMessage($"{_showName}{job.retry_message}", MessageType.Error);
                _maoFailedJobBLL.Edit(job);
                return;
            }
            var user = _userBLL.FirstOrDefault(it => it.user_uid == register.user_uid);
            if (user == null)
            {
                job.is_del = IsDelType.是;
                job.last_retry_date = DateTime.Now;
                job.retry_time++;
                job.retry_message = $"数据异常，找不到用户【{user.name}】的信息";
                _JobFrom.ShowMessage($"{_showName}{job.retry_message}", MessageType.Error);
                _maoFailedJobBLL.Edit(job);
                return;
            }

            _JobFrom.ShowMessage($"{ _showName }第{ job.retry_time }次更新人脸一体机【{mao.mao_name}】上<{ user.name }>的审核状态！", MessageType.Information);


            Face.Common_.Face face = FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), FaceVender.EyeCool);
            var reviewResult = face.Review(_ProjectCode, user.people_id, register.face_id, register.check_state, _showName);
            if (reviewResult.IsSuccess)
            {
                _JobFrom.ShowMessage($"{_showName} 人脸一体机【{mao.mao_name}】上<{ user.name }>的审核状态同步成功！", MessageType.Success);
                job.retry_time++;
                job.last_retry_date = DateTime.Now;
                job.is_del = IsDelType.是;
                job.retry_message = "审核状态同步成功！";
            }
            else
            {
                job.retry_time++;
                job.last_retry_date = DateTime.Now;
                job.retry_message = reviewResult.ToAlertString();
                _JobFrom.ShowMessage($"{_showName} 人脸一体机【{mao.mao_name}】上<{ user.name }>的审核状态同步失败：{ job.retry_message }！", MessageType.Success);
            }

            _maoFailedJobBLL.Edit(job);
        }
        /// <summary>
        /// 自动修复向一体机上注册人脸信息
        /// </summary>
        /// <param name="job"></param>
        /// <param name="mao"></param>
        private void Register(MaoFailedJob job, Mao mao)
        {
            Register register = _registerBLL.FirstOrDefault(it => it.id == job.register_or_user_id);
            if (register == null)
            {
                job.is_del = IsDelType.是;
                job.last_retry_date = DateTime.Now;
                job.retry_time++;
                job.retry_message = $"数据异常，找不到人脸注册信息【register.id:{job.register_or_user_id}】";
                _JobFrom.ShowMessage($"{_showName}{job.retry_message}", MessageType.Error);
                _maoFailedJobBLL.Edit(job);
                return;
            }
            var user = _userBLL.FirstOrDefault(it => it.user_uid == register.user_uid);
            if (user == null)
            {
                job.is_del = IsDelType.是;
                job.last_retry_date = DateTime.Now;
                job.retry_time++;
                job.retry_message = $"数据异常，找不到用户【{user.name}】的信息";
                _JobFrom.ShowMessage($"{_showName}{job.retry_message}", MessageType.Error);
                _maoFailedJobBLL.Edit(job);
                return;
            }
            _JobFrom.ShowMessage($"{ _showName }第{ job.retry_time }次更新人脸一体机【{mao.mao_name}】上【{ user.name }】的审核状态！", MessageType.Information);

            Face.Common_.Face face = FaceFactory.CreateFace(mao.GetIP(), mao.GetPort(), FaceVender.EyeCool);

            if (register.is_del == IsDelType.是)
            {
                _JobFrom.ShowMessage($"{ _showName }第{ job.retry_time }次删除人脸一体机【{mao.mao_name}】上【{ user.name }】的人脸注册信息【{ register.face_id }】！", MessageType.Information);

                var delResult = face.FaceDel(user.people_id, register.face_id);
                if (delResult.IsSuccess)
                {
                    job.is_del = IsDelType.是;
                    job.last_retry_date = DateTime.Now;
                    job.retry_time++;
                    job.retry_message = $"删除【{user.name}】的人脸注册信息【{ register.face_id }】成功";
                    _JobFrom.ShowMessage($"{ _showName }{ job.retry_message }", MessageType.Success);
                }
                else
                {
                    job.is_del = IsDelType.是;
                    job.last_retry_date = DateTime.Now;
                    job.retry_time++;
                    job.retry_message = delResult.ToAlertString();
                    _JobFrom.ShowMessage($"{ _showName } 删除【{user.name}】的人脸注册信息【{ register.face_id }】失败：{ delResult.ToAlertString() }", MessageType.Error);
                }
            }
            else
            {
                _JobFrom.ShowMessage($"{ _showName }第{ job.retry_time }次注册人脸一体机【{mao.mao_name}】上【{ user.name }】的人脸注册信息【{ register.face_id }】！", MessageType.Information);

                ActionResult registerResult = Register(user, register, face, mao, false);

                if (registerResult.IsSuccess)
                {
                    job.is_del = IsDelType.是;
                    job.last_retry_date = DateTime.Now;
                    job.retry_time++;
                    job.retry_message = "";
                    _JobFrom.ShowMessage(string.Format("**" + _showName + "照片注册成功"), MessageType.Success);
                }
                else
                {
                    job.last_retry_date = DateTime.Now;
                    job.retry_time++;
                    job.retry_message = registerResult.ToAlertString();
                    _JobFrom.ShowMessage($"{ _showName } 注册【{user.name}】的人脸注册信息【{ register.face_id }】失败：{ registerResult.ToAlertString() }", MessageType.Error);
                }
            }

            _maoFailedJobBLL.Edit(job);
        }
    }
}
