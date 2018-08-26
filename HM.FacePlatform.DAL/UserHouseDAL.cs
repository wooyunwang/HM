using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HM.Enum_.FacePlatform;
using HM.DTO.FacePlatform;

namespace HM.FacePlatform.DAL
{
    public class UserHouseDAL : BaseDAL<UserHouse>
    {
        /// <summary>
        /// 获取用户房屋关系（包含User对象、House对象）
        /// </summary>
        /// <param name="user_uid"></param>
        /// <param name="house_code"></param>
        /// <returns></returns>
        public UserHouse GetUserHouseWithUserAndHouse(string user_uid, string house_code)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.UserHouses.Include(it => it.User).Include(it => it.House)
                      .Where(it => it.user_uid == user_uid
                      && it.house_code == house_code).FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取用户房屋关系（包含User对象）
        /// </summary>
        /// <param name="user_house_id"></param>
        /// <returns></returns>
        public UserHouse GetUserHouseWithUser(int user_house_id)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.UserHouses.Include(it => it.User)
                      .Where(it => it.id == user_house_id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取用户房屋关系（包含House对象）
        /// </summary>
        /// <param name="user_uid"></param>
        /// <param name="house_code"></param>
        /// <returns></returns>
        public UserHouse GetUserHouseWithHouse(string user_uid, string house_code)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.UserHouses.Include(it => it.House)
                      .Where(it => it.user_uid == user_uid
                      && it.house_code == house_code).FirstOrDefault();
            }
        }
        /// <summary>
        /// 修改关系及用户
        /// </summary>
        /// <param name="userHouseWithUser"></param>
        /// <returns></returns>
        public int EditWithUser(UserHouse userHouseWithUser)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                db.Set<UserHouse>().Attach(userHouseWithUser);
                db.Entry(userHouseWithUser).State = EntityState.Modified;//将所有属性标记为修改状态
                db.Set<User>().Attach(userHouseWithUser.User);
                db.Entry(userHouseWithUser.User).State = EntityState.Modified;//将所有属性标记为修改状态
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_uid"></param>
        /// <returns></returns>
        public CheckNoteDto GetForCheckNote(string user_uid)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var fist = db.UserHouses.Include(it => it.House)
                      .Where(it => it.user_uid == user_uid
                      && it.is_del != IsDelType.是)
                      .Select(it => new CheckNoteDto
                      {
                          house_name = it.House.house_name,
                          user_type = it.user_type,
                          relation = it.relation,
                          user_name = it.User.name,
                          reg_time = it.User.reg_time,
                          check_note = it.User.check_note,
                          check_by = it.User.check_by,
                          check_time = it.User.check_time
                      })
                      .FirstOrDefault();

                if (fist != null)
                {
                    fist.check_by_name = db.SystemUsers.Where(it => it.id == fist.check_by).Select(it => it.user_name).FirstOrDefault();
                }

                return fist;
            }
        }

    }
}
