using HM.DTO;
using HM.DTO.FacePlatform;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;
using HM.Utils_;

namespace HM.FacePlatform.DAL
{
    public class RegisterDAL : BaseDAL<Register>
    {
        /// <summary>
        /// 获取小区用户总数，注册人脸总人数
        /// </summary>
        /// <returns></returns>
        public Tuple<int, int> GetRegistedAndUserCount()
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                int totalUser = db.Users.Where(it => it.is_del != IsDelType.是).Future().Count();
                int totalRegisted = db.Registers.Where(it => it.is_del != IsDelType.是)
                    .Select(it => it.user_uid).Distinct().Future().Count();

                return new Tuple<int, int>(totalUser, totalRegisted);
            }
        }

        public PagerData<RegisterManageDto> GetForRegisterManage(int pageIndex,
            int pageSize,
            DateTime from,
            DateTime? to,
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
                where = where.And(it => it.user.user_houses.Any(uh => uh.user_type == user_type));
            }
            where = where.And(it => it.create_time > from);
            if (to.HasValue)
            {
                DateTime dtTo = to.Value.Date.AddDays(1);
                where = where.And(it => it.create_time < dtTo);
            }
            if (register_type.HasValue)
            {
                where = where.And(it => it.register_type == register_type.Value);
            }
            if (check_state.HasValue)
            {
                where = where.And(it => it.check_state == check_state.Value);
            }

            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Set<Register>()
                    .Include(it => it.user)
                    .Where(where).AsNoTracking()
                    .Select(it => new RegisterManageDto()
                    {
                        user_uid = it.user_uid,
                        face_id = it.face_id,
                        photo_path = it.photo_path,
                        tc_path = it.tc_path,
                        register_type = it.register_type,
                        create_time = it.create_time,
                        change_time = it.change_time,
                        check_state = it.check_state,
                        is_del = it.is_del,
                        user_name = it.user.name,
                        end_time = it.user.end_time,
                        mobile = it.user.mobile,
                    });

#if DEBUG
                string sql = query.ToString();
#endif

                PagerData<RegisterManageDto> pagerData = new PagerData<RegisterManageDto>();
                pagerData.total = query.Count();
                if (pagerData.total % pageSize == 0)
                {
                    pagerData.pages = pagerData.total / pageSize;
                }
                else
                {
                    pagerData.pages = pagerData.total / pageSize + 1;
                }
                query = query.OrderBy(it => it.user_name);
                query = query.Skip(pageSize * pageIndex).Take(pageSize);
#if DEBUG
                string sqlPage = query.ToString();
#endif
                pagerData.rows = query.ToList();

                #region 多对多关系处理
                IEnumerable<string> lstUserUid = pagerData.rows.Select(it => it.user_uid);
                var lstUserHouseDto = db.UserHouses
                    .Where(it => it.is_del != IsDelType.是 && lstUserUid.Contains(it.user_uid))
                    .Select(it => new
                    {
                        it.user_uid,
                        it.user_type,
                        it.house_code,
                        it.House.house_name,
                        it.relation
                    }).ToList();

                foreach (var row in pagerData.rows)
                {
                    var lstDto = lstUserHouseDto.Where(it => it.user_uid == row.user_uid).ToList();
                    if (lstDto != null && lstDto.Any())
                    {
                        if (lstDto.Count() == 1)
                        {
                            row.house_name = lstDto[0].house_name;
                            row.user_type = lstDto[0].user_type;
                            row.relation = lstDto[0].relation;
                        }
                        else
                        {
                            row.house_name = lstDto[0].house_name + "；等";
                            row.user_type = lstDto[0].user_type;
                            row.relation = lstDto[0].relation + "；等";
                        }
                    }
                }
                #endregion
                return pagerData;
            }
        }

        public PagerData<Register> GetWithUser(int pageIndex, int pageSize, Expression<Func<Register, bool>> whereLambds)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Set<Register>()
                    .Include(it => it.user)
                    .Where(whereLambds).AsNoTracking();
#if DEBUG
                string sql = query.ToString();
#endif

                PagerData<Register> pagerData = new PagerData<Register>();
                pagerData.total = query.Count();
                if (pagerData.total % pageSize == 0)
                {
                    pagerData.pages = pagerData.total / pageSize;
                }
                else
                {
                    pagerData.pages = pagerData.total / pageSize + 1;
                }
                query = query.OrderBy(it => it.id);
                query = query.Skip(pageSize * pageIndex).Take(pageSize);
#if DEBUG
                string sqlPage = query.ToString();
#endif
                pagerData.rows = query.ToList();

                return pagerData;
            }
        }

        public Register GetWithUser(string user_uid, string face_uid)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = db.Set<Register>()
                    .Include(it => it.user)
                    .Where(it => it.user_uid == user_uid && it.face_id == face_uid).AsNoTracking();
#if DEBUG
                string sql = query.ToString();
#endif
                return query.FirstOrDefault();
            }
        }
        /// <summary>
        /// 获取注册人脸数据
        /// </summary>
        /// <param name="whereLambds"></param>
        /// <param name="isContainDel"></param>
        /// <returns></returns>
        public List<Register> GetWithUser(Expression<Func<Register, bool>> whereLambds, bool isContainDel = false)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                if (!isContainDel)
                {
                    whereLambds = whereLambds.And(it => it.is_del != IsDelType.是);
                    whereLambds = whereLambds.And(it => it.user.is_del != IsDelType.是);

                }

                var query = db.Set<Register>()
                    .Include(it => it.user)
                    .Where(whereLambds).AsNoTracking();
#if DEBUG
                string sql = query.ToString();
#endif
                return query.ToList();
            }
        }
        //        public int UpdateCheckStateByUser(string user_uid, int check_state, DateTime change_time)
        //        {
        //            string sql = string.Format(@"
        //update f_register set 
        //check_state={0},change_time='{1}' 
        //where user_uid='{2}' and register_type<>2 and check_state<>{0} and is_del=0", check_state, change_time, user_uid);
        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                return db.Execute(sql, new { check_state = check_state, user_uid = user_uid });
        //            }
        //        }

        //        public view_register[] GetListByUser(string user_uid)
        //        {
        //            string sql = @"
        //select r.*,dc.enum_name as check_state_name,dr.enum_name as register_type_name
        //from f_register r
        //inner join f_dictionary dc on dc.enum_type='CheckType' and r.check_state=dc.enum_value
        //inner join f_dictionary dr on dr.enum_type='RegisterType' and r.register_type=dr.enum_value
        //where r.is_del=0 and r.user_uid=@user_uid";
        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                var list = db.Query<view_register>(sql, new { user_uid = user_uid });
        //                view_register[] registers = list.ToArray();
        //                return registers;
        //            }
        //        }



        //        public UserRegisterDto[] GetUserListByHouse(object parameters)
        //        {
        //            string sql = GetUserListByHouseSql();

        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                var list = db.Query<UserRegisterDto>(sql, parameters);
        //                return list.ToArray<UserRegisterDto>();
        //            }
        //        }

        //        public UserRegisterDto[] GetPagedUserListByHouse(int pageNumber, int rowsPerPage, string house_code, bool includeTotalCount)
        //        {
        //            string sql = GetUserListByHouseSql();
        //            sql = GetPageSql(pageNumber, rowsPerPage, sql, "", includeTotalCount);

        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                var list = db.Query<UserRegisterDto>(sql, new { house_code = house_code });
        //                return list.ToArray<UserRegisterDto>();
        //            }
        //        }

        //        public UserRegisterDto[] GetPagedUserRegisterList(int pageNumber, int rowsPerPage
        //            , string userWhereClause, string registerWhereClause, bool includeTotalCount)
        //        {
        //            string sql = @"select uh.*,r.register_type,r.photo_path,r.register_type_name
        //from(
        //select u.*
        //    ,uh.id as user_house_id,uh.user_type,uh.relation
        //    ,h.house_code,h.house_name
        //	,dt.enum_name as user_type_name,df.enum_name as data_from_name,ds.enum_name as sex_name,dc.enum_name as check_state_name
        //    ,su.user_name as check_by_name
        //from f_user_house uh
        //inner join f_house h on uh.house_code=h.house_code
        //inner join f_user u on uh.user_uid=u.user_uid
        //inner join f_dictionary dt on dt.enum_type='UserType' and uh.user_type =dt.enum_value
        //inner join f_dictionary df on df.enum_type='DataFromType' and u.data_from =df.enum_value
        //inner join f_dictionary ds on ds.enum_type='SexType' and u.sex=ds.enum_value
        //inner join f_dictionary dc on dc.enum_type='CheckType' and u.check_state=dc.enum_value
        //left join f_system_user su on u.check_by=su.id
        //##UserWhereClause##
        //) uh 
        //inner join (
        //select r.*,dr.enum_name as register_type_name
        //from(
        //select user_uid,min(register_type) as register_type,min(photo_path) as photo_path
        //from f_register
        //##RegisterWhereClause##
        //group by user_uid
        //) r
        //inner join f_dictionary dr on dr.enum_type='RegisterType' and r.register_type=dr.enum_value
        //) r on uh.user_uid=r.user_uid";

        //            sql = sql.Replace("##UserWhereClause##", userWhereClause).Replace("##RegisterWhereClause##", registerWhereClause);
        //            sql = GetPageSql(pageNumber, rowsPerPage, sql, "", includeTotalCount);

        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                var list = db.Query<UserRegisterDto>(sql);
        //                return list.ToArray<UserRegisterDto>();
        //            }
        //        }

        //        public UserRegisterDto GetUserRegister(string whereConditions, object parameters)
        //        {
        //            string sql = GetUserRegisterSql();
        //            sql = sql.Replace("##WhereClause##", whereConditions);
        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                var list = db.Query<UserRegisterDto>(sql, parameters);
        //                UserRegisterDto[] user_registers = list.ToArray<UserRegisterDto>();
        //                if (user_registers.Length > 0)
        //                {
        //                    return user_registers[0];
        //                }
        //                return new UserRegisterDto { };
        //            }
        //        }

        //        private string GetUserRegisterSql()
        //        {
        //            return @"
        //select u.*
        //	,if(r.photo_path is null, '', r.photo_path) as photo_path 
        //    ,if(r.face_id is null, '', r.face_id) as face_id
        //from(
        //select u.*
        //    ,uh.id as user_house_id,uh.user_type,uh.relation
        //    ,h.house_code,h.house_name
        //	,dt.enum_name as user_type_name,df.enum_name as data_from_name,ds.enum_name as sex_name
        //from f_user_house uh
        //inner join f_house h on uh.house_code=h.house_code
        //inner join f_user u on uh.user_uid=u.user_uid
        //inner join f_dictionary dt on dt.enum_type='UserType' and uh.user_type =dt.enum_value
        //inner join f_dictionary df on df.enum_type='DataFromType' and u.data_from =df.enum_value
        //inner join f_dictionary ds on ds.enum_type='SexType' and u.sex=ds.enum_value
        //##WhereClause##
        //order by dt.sort_index desc
        //) u 
        //left join (
        //select user_uid, min(photo_path) as photo_path, min(face_id) as face_id
        //from f_register
        //where is_del=0
        //group by user_uid
        //) r on u.user_uid=r.user_uid";
        //        }

        //        private string GetUserListByHouseSql()
        //        {
        //            string sql = GetUserRegisterSql();
        //            sql = sql.Replace("##WhereClause##", "where uh.house_code=@house_code and u.is_del=0");
        //            return sql;
        //        }

        //        public UserRegisterDto[] GetUserListByName(string name)
        //        {
        //            string sql = GetUserRegisterSql();
        //            sql = sql.Replace("##WhereClause##", "where u.name like '%{0}%' and u.is_del=0");
        //            sql = string.Format(sql, name);
        //            using (FacePlatformDB db = new FacePlatformDB())
        //            {
        //                var list = db.Query<UserRegisterDto>(sql);
        //                return list.ToArray<UserRegisterDto>();
        //            }
        //        }

    }
}
