using HM.FacePlatform.Model;
using System;
using System.Linq;

using System.Data;
using System.Data.Entity.Migrations;
using HM.DTO;
using Z.EntityFramework.Plus;
using System.Data.Entity;
using HM.Enum_.FacePlatform;

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

                int rows = query.Count();
                if (rows % pageSize == 0)
                {
                    pagerData.pages = rows / pageSize;
                }
                else
                {
                    pagerData.pages = rows / pageSize + 1;
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
        /// 
        /// </summary>
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

                int rows = query.Count();
                if (rows % pageSize == 0)
                {
                    pagerData.pages = rows / pageSize;
                }
                else
                {
                    pagerData.pages = rows / pageSize + 1;
                }
                pagerData.rows = query.OrderBy(it => it.id)
                                    .Skip(pageSize * pageIndex)
                                    .Take(pageSize)
                                    .AsNoTracking()
                                    .ToList();
                return pagerData;
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
