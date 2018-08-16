using HM.Common_;
using HM.DTO.FacePlatform;
using HM.FacePlatform.DAL;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using HM.Utils_;
using System.Linq;
using HM.Enum_.FacePlatform;
using HM.DTO;
using System.Linq.Expressions;

namespace HM.FacePlatform.BLL
{
    public partial class RegisterBLL : BaseBLL<Register>
    {
        new RegisterDAL dal = new RegisterDAL();
        public RegisterBLL()
        {
            dal = new RegisterDAL();
        }
        /// <summary>
        /// 获取小区用户总数，注册人脸总人数
        /// </summary>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<Tuple<int, int>> GetRegistedAndUserCount()
        {
            return new ActionResult<Tuple<int, int>>()
            {
                IsSuccess = true,
                Obj = dal.GetRegistedAndUserCount()
            }; ;
        }
        [ActionResultTryCatch]
        public new ActionResult<Register> Add(Register register)
        {
            return new ActionResult<Register>()
            {
                IsSuccess = true,
                Obj = base.Add(register)
            };
        }
        /// <summary>
        /// 分页获取注册的人脸信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLambds"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<PagerData<Register>> GetWithUser(int pageIndex, int pageSize, Expression<Func<Register, bool>> whereLambds)
        {
            return new ActionResult<PagerData<Register>>()
            {
                IsSuccess = true,
                Obj = dal.GetWithUser(pageIndex, pageSize, whereLambds)
            };
        }
        /// <summary>
        /// 获取注册的人脸信息（包含用户信息对象）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="user_name"></param>
        /// <param name="user_type"></param>
        /// <param name="register_date_from"></param>
        /// <param name="register_date_to"></param>
        /// <param name="register_type"></param>
        /// <param name="check_state"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<PagerData<Register>> GetWithUser(int pageIndex,
            int pageSize,
            string user_name,
            UserType? user_type,
            RegisterType? register_type,
            CheckType? check_state)
        {
            var where = Predicate_.True<Register>();
            where = where.And(it => it.is_del == IsDelType.否);
            where = where.And(it => it.user.is_del == IsDelType.否);
            if (!string.IsNullOrWhiteSpace(user_name))
            {
                where = where.And(it => it.user.name.Contains(user_name));
            }
            if (user_type.HasValue)
            {
                where = where.And(it => it.user.UserHouses.Any(uh => uh.user_type == user_type));
            }
            if (register_type.HasValue)
            {
                where = where.And(it => it.register_type == register_type.Value);
            }
            if (check_state.HasValue)
            {
                where = where.And(it => it.check_state == check_state.Value);
            }
            return GetWithUser(pageIndex, pageSize, where);
        }

        /// <summary>
        /// 获取注册的人脸信息（包含用户信息对象）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="user_name"></param>
        /// <param name="user_type"></param>
        /// <param name="register_type"></param>
        /// <param name="check_state"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<PagerData<RegisterManageDto>> GetForRegisterManage(int pageIndex,
            int pageSize,
            DateTime from,
            DateTime? to,
            string user_name,
            UserType? user_type,
            RegisterType? register_type,
            CheckType? check_state)
        {
            var result = dal.GetForRegisterManage(pageIndex, pageSize,
                from, to, user_name,
                user_type, register_type,
                check_state);

            return new ActionResult<PagerData<RegisterManageDto>>()
            {
                IsSuccess = true,
                Obj = result
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereLambds"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<List<Register>> GetWithUser(Expression<Func<Register, bool>> whereLambds)
        {
            return new ActionResult<List<Register>>()
            {
                IsSuccess = true,
                Obj = dal.GetWithUser(whereLambds)
            };
        }
        /// <summary>
        /// 通过用户Uid获取注册人脸信息
        /// </summary>
        /// <param name="whereLambds"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<List<Register>> GetWithUser(int userid)
        {
            return GetWithUser(it => it.user.id == userid);
        }
        /// <summary>
        /// 通过用户Uid获取注册人脸信息
        /// </summary>
        /// <param name="userUid"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<List<Register>> GetWithUser(string userUid)
        {
            return GetWithUser(it => it.user_uid == userUid);
        }

        //public int UpdateCheckStateByUser(string user_uid, int check_state)
        //{
        //    try
        //    {
        //        return dal.UpdateCheckStateByUser(user_uid, check_state, DateTime.Now);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("RegisterBLL.UpdateCheckStateByUser: " + ex.Message);
        //    }
        //    return 0;
        //}

        //public Register[] GetList(string user_uid)
        //{
        //    try
        //    {
        //        return dal.GetList("where user_uid=@user_uid and is_del=@is_del", new { user_uid = user_uid, is_del = 0 });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("RegisterBLL.GetList: " + ex.Message);
        //    }
        //    return new Register[] { };
        //}

        //public Register[] GetAllList(string user_uid)
        //{
        //    try
        //    {
        //        return dal.GetList("where user_uid=@user_uid", new { user_uid = user_uid });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("RegisterBLL.GetAllList: " + ex.Message);
        //    }
        //    return new Register[] { };
        //}

        //public view_register[] GetListByUser(string user_uid)
        //{
        //    try
        //    {
        //        return dal.GetListByUser(user_uid);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("RegisterBLL.GetListByUser: " + ex.Message);
        //    }
        //    return new view_register[] { };
        //}


        //public UserRegisterDto[] GetUserListByHouse(string house_code)
        //{
        //    try
        //    {
        //        return dal.GetUserListByHouse(new { house_code = house_code });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("RegisterBLL.GetUserListByHouse: " + ex.Message);
        //    }

        //    return new UserRegisterDto[] { };
        //}
        //public UserRegisterDto[] GetUserListByName(string name, bool isWorker)
        //{
        //    try
        //    {
        //        return dal.GetUserListByName(name);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("RegisterBLL.GetUserListByName: " + ex.Message);
        //    }

        //    return new UserRegisterDto[] { };
        //}

        //public UserRegisterDto[] GetPagedUserListByHouse(int pageNumber, int rowsPerPage, string house_code, bool includeTotalCount)
        //{
        //    try
        //    {
        //        return dal.GetPagedUserListByHouse(pageNumber, rowsPerPage, house_code, includeTotalCount);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("RegisterBLL.GetPagedUserListByHouse: " + ex.Message);
        //    }

        //    return new UserRegisterDto[] { };
        //}


        //public UserRegisterDto GetUserRegisterByUid(string user_uid)
        //{
        //    try
        //    {
        //        string whereConditions = "where u.user_uid=@user_uid and u.is_del=0";
        //        return dal.GetUserRegister(whereConditions, new { user_uid = user_uid });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("RegisterBLL.GetUserRegisterByUid: " + ex.Message);
        //    }

        //    return new UserRegisterDto { };
        //}

        //public UserRegisterDto GetWorkerRegisterByName(string name)
        //{
        //    try
        //    {
        //        string whereConditions = "where u.name=@name and user_type=@user_type and u.is_del=0";
        //        return dal.GetUserRegister(whereConditions, new { name = name, user_type = (int)UserType.Worker });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("RegisterBLL.GetUserRegister: " + ex.Message);
        //    }

        //    return new UserRegisterDto { };
        //}

        //public UserRegisterDto[] GetPagedRegisterCheckStateList(int pageNumber, int rowsPerPage
        //    , string user_name, int user_type
        //    , int register_type, int photo_check_state
        //    , bool includeTotalCount)
        //{
        //    var er = Get(it => it.is_del == Enum_.FacePlatform.IsDelType.否);
        //    int all = -999;

        //    string userWhereClause = "where u.is_del=0";

        //    string registerWhereClause = string.Format("where is_del=0");

        //    if (!string.IsNullOrEmpty(user_name)) userWhereClause += string.Format(" and u.name like '%{0}%'", user_name);
        //    if (user_type != all) userWhereClause += string.Format(" and uh.user_type={0}", user_type);
        //    //if (check_state != all) userWhereClause += string.Format(" and u.check_state={0}", check_state);

        //    if (register_type != all) registerWhereClause += string.Format(" and register_type={0}", register_type);

        //    if (photo_check_state != all) registerWhereClause += string.Format(" and check_state={0}", photo_check_state);

        //    try
        //    {
        //        return dal.GetUserRegisters(pageNumber, rowsPerPage, userWhereClause, registerWhereClause, includeTotalCount);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("RegisterBLL.GetPagedRegisterCheckStateList: " + ex.Message);
        //    }

        //    return new UserRegisterDto[] { };
        //}
    }
}
