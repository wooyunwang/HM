﻿using HM.Common_;
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
        /// 分页获取需要同步至设备的用户数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>用户数据包括人脸注册数据</returns>
        public PagerData<User> GetUserForPushToDevice(int pageIndex, int pageSize, DateTime fromDate, DateTime? toDate)
        {
            return dal.GetUserForPushToDevice(pageIndex, pageSize, fromDate, toDate);
        }

        /// <summary>
        /// 通过房屋编号获取小区用户信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="houseCode"></param>
        /// <param name="key"></param>
        /// <param name="registeState"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<PagerData<User>> GetUserByHouseCode(int pageIndex, int pageSize, string houseCode, string key, bool? registeState)
        {
            return new ActionResult<PagerData<User>>()
            {
                IsSuccess = true,
                Obj = dal.GetUserByHouseCode(pageIndex, pageSize, houseCode, key)
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
                Obj = dal.GetUserByHouseCode(houseCode)
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

            var worker = FirstOrDefault(it => it.name == workerName && it.UserHouses.Any(uh => uh.user_type == UserType.工作人员 && uh.is_del != IsDelType.是) && it.is_del != IsDelType.是);
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
