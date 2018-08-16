using HM.FacePlatform.Model;
using System;
using System.Linq;

using System.Data;
using System.Data.Entity.Migrations;
using HM.DTO;
using Z.EntityFramework.Plus;
using System.Data.Entity;
using HM.Enum_.FacePlatform;
using System.Collections.Generic;
using HM.DTO.FacePlatform;

namespace HM.FacePlatform.DAL
{
    public class UserDAL : BaseDAL<User>
    {
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
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Users.IncludeOptimized(
                    x => x.Registers.Where(p =>
                    p.is_del != IsDelType.是
                    && p.create_time > fromDate
                    && p.create_time < toDate
                    ))
                    .Where(it => it.is_del != IsDelType.是);

                PagerData<User> pagerData = new PagerData<User>();
                pagerData.total = query.Count();
                if (pagerData.total % pageSize == 0)
                {
                    pagerData.pages = pagerData.total / pageSize;
                }
                else
                {
                    pagerData.pages = pagerData.total / pageSize + 1;
                }
                pagerData.rows = query.OrderBy(it => it.id)
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToList();
                return pagerData;
            }
        }
        /// <summary>
        /// 通过房屋编号获取小区用户信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="houseCode"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public PagerData<User> GetUserByHouseCode(int pageIndex, int pageSize, string houseCode, string key)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Users.IncludeOptimized(
                    x => x.Registers.Where(p =>
                    p.is_del != IsDelType.是
                    ))
                    .Where(it => it.is_del != IsDelType.是);

                PagerData<User> pagerData = new PagerData<User>();
                pagerData.total = query.Count();
                if (pagerData.total % pageSize == 0)
                {
                    pagerData.pages = pagerData.total / pageSize;
                }
                else
                {
                    pagerData.pages = pagerData.total / pageSize + 1;
                }
                pagerData.rows = query.OrderBy(it => it.id)
                                    .Skip(pageSize * pageIndex)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToList();
                return pagerData;
            }
        }
        /// <summary>
        /// 通过房屋编号获取小区用户信息
        /// </summary>
        /// <param name="house_code"></param>
        /// <returns></returns>
        public List<UserForDataBaseDto> GetUserByHouseCode(string house_code)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = from u in db.Users
                            join uh in db.UserHouses
                            on u.user_uid equals uh.user_uid
                            where u.is_del != IsDelType.是
                            && uh.is_del != IsDelType.是
                            && uh.house_code == house_code
                            orderby uh.user_type
                            select new UserForDataBaseDto
                            {
                                data_from = u.data_from,
                                id = u.id,
                                id_num = u.id_num,
                                id_type = u.id_type,
                                mobile = u.mobile,
                                name = u.name,
                                sex = u.sex,
                                user_uid = u.user_uid,
                                relation = uh.relation,
                                user_type = uh.user_type
                            };
#if DEBUG
                string sql = query.ToString();
#endif
                return query.ToList();
            }
        }

        //[Obsolete("wait")]
        //public int? Add(User user, UserHouse userHouse)
        //{
        //    using (FacePlatformDB db = new FacePlatformDB())
        //    {
        //        db.Users.Add(user);
        //        db.UserHouses.Add(userHouse);
        //        return db.SaveChanges();
        //    }
        //}
        //[Obsolete("wait")]
        //public bool Update(User user, UserHouse userHouse)
        //{

        //    using (FacePlatformDB db = new FacePlatformDB())
        //    {
        //        db.Users.AddOrUpdate(user);
        //        db.UserHouses.AddOrUpdate(userHouse);
        //        return db.SaveChanges() > 0;
        //    }
        //}
    }
}
