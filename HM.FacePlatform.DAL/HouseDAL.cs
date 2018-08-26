using HM.DTO;
using HM.DTO.FacePlatform;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Z.EntityFramework.Plus;

namespace HM.FacePlatform.DAL
{
    public class HouseDAL : BaseDAL<House>
    {
        /// <summary>
        /// 根据楼栋编码获取房屋分页数据（保护用户数据）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="buildingCode"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public PagerData<HouseForRegisterDto> GetPageHouseForRegisterDto(int pageIndex, int pageSize, string buildingCode, string userName)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                IQueryable<House> query = db.Houses.Where(it => it.building_code == buildingCode);
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    query = query.Where(it => it.user_houses.Any(uh => uh.is_del != IsDelType.是
                      && uh.User.name.Contains(userName)));
                }

                PagerData<HouseForRegisterDto> pagerData = new PagerData<HouseForRegisterDto>();
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
                    .Select(it => new HouseForRegisterDto()
                    {
                        id = it.id,
                        house_code = it.house_code,
                        house_name = it.house_name,
                        unit = it.unit,
                        building_code = it.building_code,
                        floor = it.floor,
                        roomnumber = it.roomnumber,
                        create_date = it.create_date,
                        guest_count = it.user_houses.Where(uh => uh.is_del != IsDelType.是 && uh.user_type == UserType.访客).Count(),
                        family_count = it.user_houses.Where(uh => uh.is_del != IsDelType.是 && uh.user_type == UserType.家庭成员).Count()
                    })
                    .ToList();
                #region 多对多关系处理
                IEnumerable<string> lstHouseCode = pagerData.rows.Select(it => it.house_code);
                var query2 = db.UserHouses
                    .Where(it => it.is_del != IsDelType.是
                    && (it.user_type == UserType.业主_拥有 || it.user_type == UserType.业主_居住)
                    && lstHouseCode.Contains(it.house_code))
                    .Select(it => new
                    {
                        it.user_type,
                        it.house_code,
                        it.User.name,
                    });

#if DEBUG
                string sql2 = query2.ToString();
#endif

                var lstUserHouseDto = query2.ToList();

                foreach (var row in pagerData.rows)
                {
                    var lstDto = lstUserHouseDto.Where(it => it.house_code == row.house_code).ToList();
                    if (lstDto != null && lstDto.Any())
                    {
                        row.users_string = string.Join("；", lstDto.OrderBy(it => it.user_type).ThenBy(it => it.name).Select(it => it.name));//此处为内存排序
                    }
                }
                #endregion

                return pagerData;
            }
        }

        /// <summary>
        ///  通过房号获取房屋用户关系信息（包括User对象、House对象）
        /// </summary>
        /// <param name="house_code"></param>
        /// <returns></returns>
        public List<UserHouse> GetUserHouseWithUserAndHouse(string house_code)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.UserHouses
                    .Include(it => it.User)
                    .Include(it => it.House)
                    .Where(it => it.house_code == house_code && it.is_del != IsDelType.是);
#if DEBUG
                string sql = query.ToString();
#endif
                return query.ToList().OrderBy(it => it.user_type)
                    .ThenBy(it => it.User.name).ToList();//MySql数据库中文排序有问题，只能利用内存排序。
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
