using HM.Common_;
using HM.DTO;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.DAL;

using HM.FacePlatform.Model;
using HM.Utils_;
using System;

namespace HM.FacePlatform.BLL
{
    public class ActionLogBLL : BaseBLL<ActionLog>
    {
        new ActionLogDAL dal = new ActionLogDAL();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="key"></param>
        /// <param name="admin_type"></param>
        /// <param name="action_name"></param>
        /// <param name="system_user_id"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<PagerData<CheckActionLogDto>> GetCheckLog(int pageIndex, int pageSize,
            DateTime from, DateTime? to,
            string key, IsAdminType? admin_type,
            ActionName? action_name,
            int? system_user_id)
        {

            var pagerData = dal.GetCheckLog(pageIndex, pageSize, from, to, key, admin_type, action_name, system_user_id);
            return new ActionResult<PagerData<CheckActionLogDto>>()
            {
                IsSuccess = true,
                Obj = pagerData
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="key"></param>
        /// <param name="admin_type"></param>
        /// <param name="action_name"></param>
        /// <param name="system_user_id"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<PagerData<BaseDataActionLogDto>> GetBaseDataLog(int pageIndex, int pageSize,
            DateTime from, DateTime? to,
            string key, IsAdminType? admin_type,
            ActionName? action_name,
            int? system_user_id)
        {

            var pagerData = dal.GetBaseDataLog(pageIndex, pageSize, from, to, key, admin_type, action_name, system_user_id);
            return new ActionResult<PagerData<BaseDataActionLogDto>>()
            {
                IsSuccess = true,
                Obj = pagerData
            };
        }

        /// <summary>
        /// 获取平台注册日志
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <param name="user_type"></param>
        /// <param name="action_name"></param>
        /// <param name="system_user_id"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<PagerData<RegisterActionLogDto>> GetRegisterLog(int pageIndex, int pageSize,
            DateTime from, DateTime? to,
            string name, UserType? user_type,
            ActionName? action_name,
            int? system_user_id)
        {
            var pagerData = dal.GetRegisterLog(pageIndex, pageSize, from, to, name, user_type, action_name, system_user_id);
            return new ActionResult<PagerData<RegisterActionLogDto>>()
            {
                IsSuccess = true,
                Obj = pagerData
            };
        }
    }
}
