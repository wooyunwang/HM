using HM.DTO;
using HM.DTO.FacePlatform;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Z.EntityFramework.Plus;

namespace HM.FacePlatform.DAL
{
    public class UserDAL : BaseDAL<User>
    {
        /// <summary>
        /// 分页获取需要同步至设备的用户数据
        /// </summary>
        /// <param name="maoId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="returnTotal">是否返回total</param>
        /// <returns>用户数据包括人脸注册数据</returns>
        public PagerData<User> GetUserWithRegisterForPushToDevice(int? maoId, int pageIndex, int pageSize, DateTime fromDate, DateTime? toDate, bool returnTotal = true)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Users.Where(it => it.is_del != IsDelType.是);

                if (maoId.HasValue)
                {
                    query = from q in db.Users
                            join uh in db.UserHouses
                            on q.user_uid equals uh.user_uid
                            join h in db.Houses
                            on uh.house_code equals h.house_code
                            join mb in db.MaoBuildings
                            on h.building_code equals mb.building_code
                            where uh.is_del != IsDelType.是
                            && mb.is_del != IsDelType.是
                            && mb.mao_id == maoId
                            select q;
                }

                query = query.IncludeOptimized(
                    x => x.registers.Where(p =>
                    p.is_del != IsDelType.是
                    && p.check_state != CheckType.审核不通过 //审核不通过的，不能同步，接口也不支持！
                    && p.create_time > fromDate
                    && p.create_time < toDate
                    ));

#if DEBUG
                string sql = query.ToString();
#endif

                PagerData<User> pagerData = new PagerData<User>();

                if (returnTotal)
                {
                    pagerData.total = query.Count();
                    if (pagerData.total % pageSize == 0)
                    {
                        pagerData.pages = pagerData.total / pageSize;
                    }
                    else
                    {
                        pagerData.pages = pagerData.total / pageSize + 1;
                    }
                }
                else
                {
                    pagerData.total = -1;
                    pagerData.pages = -1;
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
        /// 分页获取需要同步至云平台的用户数据
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="top">前多少条，null时默认全部</param>
        /// <returns>小区用户数据包括用户房屋关系数据</returns>
        public List<User> GetUserForPushToCloud(DateTime fromDate, DateTime? toDate, int? top = null)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Users.Include(it => it.user_houses)
                    .Where(it => it.is_del != IsDelType.是)
                    .Where(it => it.user_houses.Any(uh => uh.is_del != IsDelType.是))
                    .Where(it => it.change_time >= fromDate);
#if DEBUG
                string sql = query.ToString();
#endif
                if (toDate.HasValue)
                {
                    query = query.Where(it => it.change_time <= toDate);
                }

                var query2 = query.OrderBy(it => it.change_time)
                     .AsNoTracking();
#if DEBUG
                string sql2 = query2.ToString();
#endif
                if (top.HasValue)
                {

                    return query2.Take(top.Value).ToList();
                }
                else
                {
                    return query2.ToList();
                }
            }
        }
        /// <summary>
        /// 通过uid获取用户信息（包含用户房屋关系对象）
        /// </summary>
        /// <param name="user_uid"></param>
        /// <returns></returns>
        public User GetUserWithUserHouse(string user_uid)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.Users.Include(it => it.user_houses)
                      .Where(it => it.user_uid == user_uid).FirstOrDefault();
            }
        }

        /// <summary>
        /// 通过房屋编号获取小区用户信息（包含属于houseCode的UserHouses对象）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="houseCode"></param>
        /// <param name="key">姓名或者手机号码</param>
        /// <param name="registeState"></param>
        /// <returns></returns>
        public PagerData<User> GetWorkerUserForRegister(int pageIndex, int pageSize, string houseCode, string key, bool? registeState)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Users.IncludeOptimized(
                    x => x.user_houses.Where(p =>
                    p.is_del != IsDelType.是 && p.house_code == houseCode
                    ))
                    .Where(it => it.is_del != IsDelType.是)
                    .Where(it => it.user_houses.Any(p =>
                         p.is_del != IsDelType.是
                         && p.house_code == houseCode
                    ));

                if (!string.IsNullOrWhiteSpace(key))
                {
                    if (Utils_.Validate_.IsCHZN(key))
                    {
                        query = query.Where(it => it.name.Contains(key));
                    }
                    else if (Utils_.Validate_.IsNumber(key))
                    {
                        query = query.Where(it => it.mobile.Contains(key));
                    }
                }
                if (registeState.HasValue)
                {
                    CheckType check_state = registeState.Value ? CheckType.审核通过 : CheckType.审核不通过;
                    query = query.Where(it => it.check_state == check_state);
                }
#if DEBUG
                string sql = query.ToString();
#endif
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

        /// <summary>
        /// 获取用户的用户类型（默认第一个）
        /// </summary>
        /// <param name="user_uid"></param>
        /// <returns></returns>
        public UserType GetUserType(string user_uid)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.UserHouses.Where(it => it.user_uid == user_uid && it.is_del != IsDelType.是).OrderBy(it => it.id).Select(it => it.user_type).FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取用户（包含指定的人脸注册信息）
        /// </summary>
        /// <param name="user_uid"></param>
        /// <param name="lstFaceId"></param>
        /// <returns></returns>
        public User GetUserWithRegister(string user_uid, IEnumerable<string> lstFaceId)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Users.Where(it => it.user_uid == user_uid)
                     .IncludeOptimized(
                     x => x.registers.Where(p => lstFaceId.Contains(p.face_id)));
#if DEBUG
                string sql = query.ToString();
#endif
                return query.FirstOrDefault();
            }
        }
        
        /// <summary>
        /// 获取相关楼栋下的用户（包含相关的人脸注册信息【排除已删除的】）
        /// </summary>
        /// <param name="lstBuildingCode"></param>
        /// <returns></returns>
        public List<User> GetUserWithRegisterForMapBuilding(IEnumerable<string> lstBuildingCode)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Users.Where(it => it.is_del != IsDelType.是)
                    .Where(it =>
                       it.user_houses.Any(
                       uh => lstBuildingCode.Contains(uh.House.building_code
                       )))
                    .IncludeOptimized(x => x.registers.Where(p => p.is_del != IsDelType.是));
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
