using HM.DTO;
using HM.FacePlatform.WeChatModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HM.FacePlatform.WeChat.DAL
{
    public class User_W_DAL : BaseDAL<w_user>
    {
        /// <summary>
        /// 分页获取某项目下的用户信息（包含该项目下的UserHouse关系对象）
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagerData<w_user> GetUserWithUserHouse(string project_code, int pageIndex, int pageSize)
        {
            using (WeChatDB db = new WeChatDB())
            {
                var query = db.w_user.Include(it => it.user_houses)
                    .Where(it => it.user_houses.Any(uh => uh.project_code == project_code));

#if DEBUG
                string sql = query.ToString();
#endif

                PagerData<w_user> pagerData = new PagerData<w_user>();
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
            using (WeChatDB db = new WeChatDB())
            {
                var query = db.w_user.Include(it => it.user_houses)
                    .Where(it => it.user_houses.Any(uh => uh.project_code == project_code));

                query = query.Where(it => it.lastupdate_time >= from || it.user_houses.Any(uh => uh.lastupdate_time >= from));
                if (to.HasValue)
                {
                    query = query.Where(it => it.lastupdate_time < to || it.user_houses.Any(uh => uh.lastupdate_time < to));
                }

#if DEBUG
                string sql = query.ToString();
#endif
                if (top.HasValue)
                {
                    query = query.OrderBy(it => it.lastupdate_time).Take(top.Value);
                }
                else
                {
                    query = query.OrderBy(it => it.lastupdate_time);
                }
#if DEBUG
                string sqlPage = query.ToString();
#endif
                return query.ToList();
            }
        }

        /// <summary>
        /// 分页获取某项目下的用户信息（包含该项目下的UserHouse关系对象）
        /// </summary>
        /// <param name="project_code"></param>
        /// <param name="user_uid"></param>
        /// <returns></returns>
        public w_user GetUserWithUserHouse(string project_code, string user_uid)
        {
            using (WeChatDB db = new WeChatDB())
            {
                var query = db.w_user.Include(it => it.user_houses)
                    .Where(it => it.user_houses.Any(uh => uh.project_code == project_code));

                query = query.Where(it => it.user_uid == user_uid);
#if DEBUG
                string sql = query.ToString();
#endif
                return query.FirstOrDefault();
            }
        }
    }
}
