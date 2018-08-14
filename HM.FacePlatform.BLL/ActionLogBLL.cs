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
        /// <param name="action_type"></param>
        /// <param name="system_user_id"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<PagerData<ActionLogDto>> GetLogButRegister(int pageIndex, int pageSize,
            DateTime from, DateTime? to,
            string key, IsAdminType? admin_type,
            ActionType action_type,
            ActionName? action_name,
            int? system_user_id)
        {
            switch (action_type)
            {
                case ActionType.未知:
                    throw new Exception($"未提供对【{EnumHelper.GetName(action_type)}】日志的查询！");
                case ActionType.审核:
                case ActionType.基础数据:
                    var pagerData = dal.GetLogButRegister(pageIndex, pageSize, from, to, key, admin_type, action_type, action_name, system_user_id);
                    return new ActionResult<PagerData<ActionLogDto>>()
                    {
                        IsSuccess = true,
                        Obj = pagerData
                    };
                case ActionType.平台注册:
                default:
                    throw new Exception($"【{EnumHelper.GetName(action_type)}】日志不应该调用此方法！");
            }
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
        /// <param name="admin_type"></param>
        /// <param name="system_user_id"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<PagerData<RegisterActionLogDto>> GetRegisterLog(int pageIndex, int pageSize,
            DateTime from, DateTime? to,
            string name, string key, UserType? user_type,
            IsAdminType? admin_type,
            int? system_user_id)
        {
            var pagerData = dal.GetRegisterLog(pageIndex, pageSize, from, to, name, key, user_type, admin_type, system_user_id);
            return new ActionResult<PagerData<RegisterActionLogDto>>()
            {
                IsSuccess = true,
                Obj = pagerData
            };
        }
    }
}
