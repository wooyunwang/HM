using HM.Common_;
using HM.DTO;
using HM.DTO.FacePlatform;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.DAL;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HM.FacePlatform.BLL
{
    public class UserBLL : BaseBLL<User>
    {
        new UserDAL dal = new UserDAL();

        /// <summary>
        /// 分页获取需要同步至设备的用户数据（分块）
        /// </summary>
        /// <param name="mao"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="withCount">是否返回total</param>
        /// <returns>用户数据包括人脸注册数据</returns>
        public PagerData<User> GetUserWithRegisterForPushToDevice(int? mao, int pageIndex, int pageSize, DateTime fromDate, DateTime? toDate, bool returnTotal = true)
        {
            return dal.GetUserWithRegisterForPushToDevice(mao, pageIndex, pageSize, fromDate, toDate, returnTotal);
        }
        /// <summary>
        /// 分页获取需要同步至云平台的用户数据
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="top">前多少条，null时默认全部</param>
        /// <returns>小区用户数据包括用户房屋关系数据</returns>
        public List<User> GetUserForPushToCloud(DateTime fromDate, DateTime? toDate, int? top = null)
        {
            return dal.GetUserForPushToCloud(fromDate, toDate, top);
        }

        /// <summary>
        /// 通过uid获取用户信息（包含用户房屋关系对象）
        /// </summary>
        /// <param name="user_uid"></param>
        /// <returns></returns>
        public User GetUserWithUserHouse(string user_uid)
        {
            return dal.GetUserWithUserHouse(user_uid);
        }

        /// <summary>
        /// 通过房屋编号获取小区工作人员信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="houseCode"></param>
        /// <param name="key">姓名或者手机号码</param>
        /// <param name="registeState"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<PagerData<User>> GetWorkerUserForRegister(int pageIndex, int pageSize, string houseCode, string key, bool? registeState)
        {
            return new ActionResult<PagerData<User>>()
            {
                IsSuccess = true,
                Obj = dal.GetWorkerUserForRegister(pageIndex, pageSize, houseCode, key, registeState)
            };
        }
        /// <summary>
        /// 通过房屋编号获取小区用户信息
        /// </summary>
        /// <param name="houseCode"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<List<UserForDataBaseDto>> GetUserByHouseCode(string houseCode)
        {
            return new ActionResult<List<UserForDataBaseDto>>()
            {
                IsSuccess = true,
                Obj = dal.GetUserByHouseCode((string)houseCode)
            };
        }
        /// <summary>
        /// 通过名称获取工作人员
        /// </summary>
        /// <param name="workerName"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<User> GetWorkerByName(string workerName)
        {
            ActionResult<User> result = new ActionResult<User>();

            var worker = FirstOrDefault(it => it.name == workerName && it.user_houses.Any(uh => uh.user_type == UserType.工作人员 && uh.is_del != IsDelType.是) && it.is_del != IsDelType.是);
            if (worker == null)
            {
                result.IsSuccess = false;
                result.Add($"未能查询到工作人员【{workerName}】");
                return result;
            }
            else
            {
                return new ActionResult<User>()
                {
                    IsSuccess = true,
                    Obj = worker
                };
            }
        }
        /// <summary>
        /// 获取用户的用户类型（默认第一个）
        /// </summary>
        /// <param name="user_uid"></param>
        /// <returns></returns>
        public UserType GetUserType(string user_uid)
        {
            return dal.GetUserType(user_uid);
        }
        /// <summary>
        /// 获取用户（包含指定的人脸注册信息）
        /// </summary>
        /// <param name="user_uid"></param>
        /// <param name="lstFaceId"></param>
        /// <returns></returns>
        public User GetUserWithRegister(string user_uid, IEnumerable<string> lstFaceId)
        {
            return dal.GetUserWithRegister(user_uid, lstFaceId);
        }

        //public bool IsExist(string type, int id, string value)
        //{
        //    try
        //    {
        //        string conditions = "where id<>@id and ";
        //        object parameters = null;
        //        if (type == "mobile")
        //        {
        //            conditions += "mobile=@mobile";
        //            parameters = new { id = id, mobile = value };
        //        }
        //        else if (type == "id_num")
        //        {
        //            conditions += "id_num=@id_num";
        //            parameters = new { id = id, id_num = value };
        //        }
        //        return dal.RecordCount(conditions, parameters) > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("UserBLL.IsExist: " + ex.Message);
        //    }

        //    return true;
        //}

        //public bool Add(User user, UserHouse userHouse, int action_by, string remark)
        //{
        //    try
        //    {
        //        int id = Convert.ToInt32(dal.Add(user, userHouse));

        //        if(id > 0)
        //        {
        //            ActionLog log = new ActionLog
        //            {
        //                table_id = id,
        //                action_type = (int)ActionType.User,
        //                action = (int)ActionName.Add,
        //                action_by = action_by,
        //                remark = remark,
        //            };
        //            _actionLogBLL.Add(log);

        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("UserBLL.Add: " + ex.Message);
        //    }
        //    return false;
        //}

        //public bool Add(User user, int action_by, string remark)
        //{
        //    try
        //    {
        //        int id = Convert.ToInt32(dal.Add(user));

        //        if (id > 0)
        //        {
        //            ActionLog log = new ActionLog
        //            {
        //                table_id = id,
        //                action_type = (int)ActionType.User,
        //                action = (int)ActionName.Add,
        //                action_by = action_by,
        //                remark = remark,
        //            };
        //            _actionLogBLL.Add(log);

        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("UserBLL.Add: " + ex.Message);
        //    }
        //    return false;
        //}

        //public bool Update(User user, UserHouse userHouse, int action_by)
        //{
        //    try
        //    {
        //        ActionLog log = new ActionLog
        //        {
        //            table_id = user.id,
        //            action_type = (int)ActionType.User,
        //            action = (int)ActionName.Edit,
        //            action_by = action_by,
        //        };
        //        _actionLogBLL.Add(log);

        //        return dal.Update(user, userHouse);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("UserBLL.Update: " + ex.Message);
        //    }
        //    return false;
        //}

        //public int UpdateUserOnly(User user)
        //{
        //    try
        //    {
        //        return dal.UpdateUserOnly(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("UserBLL.UpdateUserOnly: " + ex.Message);
        //    }
        //    return 0;
        //}
    }
}
