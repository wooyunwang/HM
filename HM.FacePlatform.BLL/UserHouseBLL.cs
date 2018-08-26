using HM.Common_;
using HM.DTO;
using HM.DTO.FacePlatform;
using HM.FacePlatform.DAL;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HM.FacePlatform.BLL
{
    public class UserHouseBLL : BaseBLL<UserHouse>
    {
        new UserHouseDAL dal = new UserHouseDAL();
        /// <summary>
        /// 获取用户房屋关系（包含User对象、House对象）
        /// </summary>
        /// <param name="user_uid"></param>
        /// <param name="house_code"></param>
        /// <returns></returns>
        public UserHouse GetUserHouseWithUserAndHouse(string user_uid, string house_code)
        {
            return dal.GetUserHouseWithUserAndHouse(user_uid, house_code);
        }
        /// <summary>
        /// 获取用户房屋关系（包含User对象）
        /// </summary>
        /// <param name="user_house_id"></param>
        /// <returns></returns>
        public UserHouse GetUserHouseWithUser(int user_house_id)
        {
            return dal.GetUserHouseWithUser(user_house_id);
        }

        /// <summary>
        /// 获取用户房屋关系（包含House对象）
        /// </summary>
        /// <param name="user_uid"></param>
        /// <param name="house_code"></param>
        /// <returns></returns>
        public UserHouse GetUserHouseWithHouse(string user_uid, string house_code)
        {
            return dal.GetUserHouseWithHouse(user_uid, house_code);
        }

        /// <summary>
        /// 修改关系及用户
        /// </summary>
        /// <param name="userHouseWithUser"></param>
        /// <returns></returns>
        [ActionResultTryCatch]
        public ActionResult<int> EditWithUser(UserHouse userHouseWithUser)
        {
            return new ActionResult<int>()
            {
                IsSuccess = true,
                Obj = dal.EditWithUser(userHouseWithUser)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_uid"></param>
        /// <returns></returns>
        public CheckNoteDto GetForCheckNote(string user_uid)
        {
            return dal.GetForCheckNote(user_uid);
        }
    }
}
