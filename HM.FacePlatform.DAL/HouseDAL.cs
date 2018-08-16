using System;
using HM.FacePlatform.Model;
using System.Linq;
using System.Threading.Tasks;
using HM.Enum_.FacePlatform;
using System.Collections.Generic;
using HM.DTO;
using Z.EntityFramework.Plus;
using System.Data.Entity;
using HM.DTO.FacePlatform;

namespace HM.FacePlatform.DAL
{
    public class HouseDAL : BaseDAL<House>
    {
        /// <summary>
        /// 根据楼栋编码获取房屋分页数据（保护用户数据）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public PagerData<House> GetHousePageByBuildingCode(int pageIndex, int pageSize, string userName)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                IQueryable<House> query = null;
                if (string.IsNullOrWhiteSpace(userName))
                {
                    query = db.Houses.IncludeOptimized(
                        x => x.UserHouses.Where(p =>
                        p.is_del != IsDelType.是
                        ));
                }
                else
                {
                    query = db.Houses.IncludeOptimized(
                        x => x.UserHouses.Where(p =>
                        p.is_del != IsDelType.是
                        && p.User.name.Contains(userName)
                        ));
                }

                PagerData<House> pagerData = new PagerData<House>();
                pagerData.total = query.Count();
                if (pagerData.total % pageSize == 0)
                {
                    pagerData.pages = pagerData.total / pageSize;
                }
                else
                {
                    pagerData.pages = pagerData.total / pageSize + 1;
                }
                pagerData.rows = query.OrderBy(it => it.roomnumber)
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToList();

                return pagerData;
            }
        }
        //        public int RecordCount(object parameters = null)
        //        {
        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                return db.RecordCount<House>(parameters);
        //            }
        //        }


        //        public view_user_house[] GetUserList(DateTime from, DateTime to)
        //        {
        //            string sql = @"
        //select u.*,uh.user_type,uh.relation,uh.house_code
        //from f_user_house uh
        //inner join f_user u on uh.user_uid=u.user_uid
        //where u.change_time between @from and @to";
        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                var list = db.Query<view_user_house>(sql, new { from = from, to = to });
        //                return list.ToArray();
        //            }
        //        }

        //        public view_user_house[] GetStatistics(int pageNumber, int rowsPerPage, string building_code, bool includeTotalCount)
        //        {
        //            //            string sql = @"
        //            //select h.house_code,h.house_name, uh.name
        //            //	,ifnull(family_count,0) as family_count,ifnull(guest_count,0) as guest_count
        //            //from f_house h
        //            //left join (
        //            //select house_code,group_concat(name) as name
        //            //	,sum(family_count) as family_count,sum(guest_count) as guest_count
        //            //from (
        //            //select uh.house_code
        //            //,case when uh.user_type=1 or uh.user_type=2 then u.name else '' end as name
        //            //,case when user_type=3 then 1 else 0 end as family_count
        //            //,case when user_type=4 then 1 else 0 end as guest_count
        //            //from f_user_house uh
        //            //inner join f_user u on uh.user_uid=u.user_uid
        //            //) uh group by house_code
        //            //) uh on h.house_code=uh.house_code
        //            //where h.building_code=@building_code";

        //            string sql = @"
        //select h.house_code,h.house_name,'-' as name,'-' as family_count,'-' as guest_count
        //from f_house h
        //where h.building_code=@building_code";

        //            sql = GetPageSql(pageNumber, rowsPerPage, sql, "house_name", includeTotalCount);

        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                var list = db.Query<view_user_house>(sql, new { building_code = building_code });
        //                return list.ToArray<view_user_house>();
        //            }
        //        }

        //        public view_user_house[] GetHouseStatistics(string house_code)
        //        {
        //            string sql = @"select group_concat(name) as name
        //	,sum(family_count) as family_count,sum(guest_count) as guest_count
        //from (
        //select uh.house_code
        //,case when uh.user_type=1 or uh.user_type=2 then u.name else '' end as name
        //,case when user_type=3 then 1 else 0 end as family_count
        //,case when user_type=4 then 1 else 0 end as guest_count
        //from f_user_house uh
        //inner join f_user u on uh.user_uid=u.user_uid
        //where uh.house_code=@house_code
        //) uh group by house_code";

        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                var list = db.Query<view_user_house>(sql, new { house_code = house_code });
        //                return list.ToArray();
        //            }
        //        }

    }
}
