using HM.DTO;
using HM.Enum_.FacePlatform;
using HM.FacePlatform.Model;
using HM.Utils_;
using System;
using System.Linq;

namespace HM.FacePlatform.DAL
{
    public class ActionLogDAL : BaseDAL<ActionLog>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="key"></param>
        /// <param name="admin_type"></param>
        /// <param name="action_type"></param>
        /// <param name="action_name"></param>
        /// <param name="system_user_id"></param>
        /// <returns></returns>
        public PagerData<ActionLogDto> GetLogButRegister(int pageIndex, int pageSize,
           DateTime from, DateTime? to,
           string key, IsAdminType? admin_type,
           ActionType? action_type,
           ActionName? action_name,
           int? system_user_id)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = from al in db.Set<ActionLog>()
                            join su in db.Set<SystemUser>()
                            on al.action_by equals su.id
                            select new ActionLogDto
                            {
                                id = al.id,
                                action = al.action,
                                action_by = al.action_by,
                                action_type = al.action_type,
                                create_date = al.create_date,
                                table_id = al.table_id,
                                remark = al.remark,
                                system_user_name = su.user_name,
                                is_admin = su.is_admin
                            };

                var where = Predicate_.True<ActionLogDto>();
                where = where.And(it => it.create_date > from);
                if (to.HasValue)
                {
                    DateTime dtTo = to.Value.Date.AddDays(1).AddSeconds(-1);
                    where = where.And(it => it.create_date < dtTo);
                }
                if (!string.IsNullOrWhiteSpace(key))
                {
                    where = where.And(it => it.remark.Contains(key));
                }
                if (admin_type.HasValue)
                {
                    where = where.And(it => it.is_admin == admin_type.Value);
                }
                if (action_type.HasValue)
                {
                    where = where.And(it => it.action_type == action_type.Value);
                }
                if (action_name.HasValue)
                {
                    where = where.And(it => it.action == action_name.Value);
                }
                if (system_user_id.HasValue)
                {
                    where = where.And(it => it.action_by == system_user_id.Value);
                }

                query = query.Where(where);

#if DEBUG
                string sql = query.ToString();
#endif

                PagerData<ActionLogDto> pagerData = new PagerData<ActionLogDto>();
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
                query = query.OrderByDescending(it => it.create_date);
                query = query.Skip(pageSize * pageIndex).Take(pageSize);
#if DEBUG
                string sqlPage = query.ToString();
#endif
                pagerData.rows = query.ToList();

                return pagerData;
            }
        }
        /// <summary>
        /// 获取平台注册日志
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <param name="user_type"></param>
        /// <param name="admin_type"></param>
        /// <param name="system_user_id"></param>
        /// <returns></returns>
        public PagerData<RegisterActionLogDto> GetRegisterLog(int pageIndex, int pageSize,
            DateTime from, DateTime? to,
            string name, string key, UserType? user_type,
            IsAdminType? admin_type,
            int? system_user_id)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var query = from al in db.Set<ActionLog>()
                            join r in db.Set<Register>()
                            on al.table_id equals r.id
                            join u in db.Set<User>()
                            on r.user_uid equals u.user_uid
                            join su in db.Set<SystemUser>()
                            on al.action_by equals su.id
                            where user_type == null || u.UserHouses.Any(it => it.user_type == user_type)
                            select new RegisterActionLogDto
                            {
                                id = al.id,
                                action = al.action,
                                action_by = al.action_by,
                                action_type = al.action_type,
                                create_date = al.create_date,
                                table_id = al.table_id,
                                remark = al.remark,
                                system_user_name = su.user_name,
                                is_admin = su.is_admin,
                                user_name = u.name
                            };

                var where = Predicate_.True<RegisterActionLogDto>();
                where = where.And(it => it.create_date > from);
                if (to.HasValue)
                {
                    DateTime dtTo = to.Value.Date.AddDays(1).AddSeconds(-1);
                    where = where.And(it => it.create_date < dtTo);
                }
                if (!string.IsNullOrWhiteSpace(name))
                {
                    where = where.And(it => it.user_name.Contains(name));
                }
                if (!string.IsNullOrWhiteSpace(key))
                {
                    where = where.And(it => it.remark.Contains(key));
                }
                if (admin_type.HasValue)
                {
                    where = where.And(it => it.is_admin == admin_type.Value);
                }
                if (system_user_id.HasValue)
                {
                    where = where.And(it => it.action_by == system_user_id.Value);
                }

                query = query.Where(where);
#if DEBUG
                string sql = query.ToString();
#endif

                PagerData<RegisterActionLogDto> pagerData = new PagerData<RegisterActionLogDto>();
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
                query = query.OrderByDescending(it => it.create_date);
                query = query.Skip(pageSize * pageIndex).Take(pageSize);
#if DEBUG
                string sqlPage = query.ToString();
#endif
                pagerData.rows = query.ToList();

                return pagerData;
            }
        }
    }
}
