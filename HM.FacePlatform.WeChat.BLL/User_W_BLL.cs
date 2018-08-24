using HM.Common_;
using HM.DTO;
using HM.FacePlatform.WeChat.DAL;
using HM.FacePlatform.WeChatModel;
using System;
using System.Collections.Generic;

namespace HM.FacePlatform.WeChat.BLL
{
    public class User_W_BLL : BaseBLL<w_user>
    {
        new User_W_DAL dal = new User_W_DAL();

        /// <summary>
        /// 分页获取某项目下的用户信息（包含该项目下的UserHouse关系对象）
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagerData<w_user> GetUserWithUserHouse(string project_code, int pageIndex, int pageSize)
        {
            return dal.GetUserWithUserHouse(project_code, pageIndex, pageSize);
        }

        /// <summary>
        /// 分页获取某项目下的用户信息（包含该项目下的UserHouse关系对象）
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<w_user> GetUserWithUserHouse(string project_code, DateTime from, DateTime? to, int? top = null)
        {
            return dal.GetUserWithUserHouse(project_code, from, to, top);
        }

        /// <summary>
        /// 分页获取某项目下的某一用户信息（包含该项目下的UserHouse关系对象）
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="user_uid"></param>
        /// <returns></returns>
        public w_user GetUserWithUserHouse(string project_code, string user_uid)
        {
            return dal.GetUserWithUserHouse(project_code, user_uid);
        }
    }
}
