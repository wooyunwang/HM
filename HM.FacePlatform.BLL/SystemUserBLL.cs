using HM.Common_;
using HM.FacePlatform.DAL;
using HM.DTO;
using HM.FacePlatform.Model;
using System;
using HM.Enum_.FacePlatform;

namespace HM.FacePlatform.BLL
{
    public class SystemUserBLL : BaseBLL<SystemUser>
    {
        new SystemUserDAL dal = new SystemUserDAL();
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ActionResult<SystemUser> Login(string userName, string password)
        {
            ActionResult<SystemUser> result = new ActionResult<SystemUser>();

            if (!dal.Any(it => it.user_name == userName))
            {
                result.IsSuccess = false;
                result.Add("该用户不存在");
                return result;
            }
            else
            {
                SystemUser dbUser = dal.FirstOrDefault(it => it.user_name == userName && it.password == password);
                if (dbUser == null)
                {
                    result.IsSuccess = false;
                    result.Add("密码错误");
                    return result;
                }
                else
                {
                    if (dbUser.is_del == IsDelType.是)
                    {
                        result.IsSuccess = false;
                        result.Add("该用户已经被禁用");
                    }
                    else
                    {
                        dbUser.last_login_date = DateTime.Now;
                        dal.Edit(dbUser);
                        result.IsSuccess = true;
                        result.Obj = dbUser;
                    }
                }
            }
            return result;
        }

        //public ActionResult Add(SystemUser user)
        //{
        //    ActionResult result = new ActionResult();
        //    result.IsSuccess = false;

        //    try
        //    {
        //        SystemUser[] users = GetList("where user_name=@user_name", new { user_name = user.user_name });
        //        if (users.Length > 0)
        //        {
        //            result.Add("该用户名已存在");
        //            return result;
        //        }

        //        dal.Add(user);
        //        result.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Add(ex);

        //        LogHelper.Error("SystemUserBLL.Add: " + ex.Message);
        //    }
        //    return result;
        //}

        //public int UpdateDirectly(SystemUser user)
        //{
        //    try
        //    {
        //        return dal.Update(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("SystemUserBLL.Update: " + ex.Message);
        //    }

        //    return 0;
        //}

        //public ActionResult Update(SystemUser user)
        //{
        //    ActionResult result = new ActionResult();
        //    result.IsSuccess = false;

        //    try
        //    {
        //        SystemUser dbuser = dal.Get(user.id);
        //        if (!string.IsNullOrEmpty(user.password))
        //            dbuser.password = user.password;
        //        else dbuser.is_del = user.is_del;

        //        dal.Update(dbuser);
        //        result.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Add(ex.Message);
        //        LogHelper.Error("SystemUserBLL.Update: " + ex.Message);
        //    }

        //    return result;
        //}



        //public SystemUser[] GetList(string whereConditions, object parameters = null)
        //{
        //    try
        //    {
        //        return dal.GetList(whereConditions, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("SystemUserBLL.GetList: " + ex.Message);
        //    }
        //    return new SystemUser[] { };
        //}

        //public view_system_user[] GetList()
        //{
        //    try
        //    {
        //        return dal.GetList();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.Error("SystemUserBLL.GetList: " + ex.Message);
        //    }
        //    return new view_system_user[] { };
        //}
    }
}
