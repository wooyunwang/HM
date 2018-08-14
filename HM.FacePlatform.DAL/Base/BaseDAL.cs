using HM.FacePlatform.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace HM.FacePlatform.DAL
{
    /// <summary>
    /// 基类
    /// </summary>
    public class BaseDAL<T> where T : class, new()
    {
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <returns></returns>
        public virtual bool Any()
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.Set<T>().Any();
            }
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.Set<T>().Any(where);
            }
        }

        #region Get AsNoTracking
        /// <summary>
        /// 带条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.Set<T>().AsNoTracking().Where<T>(where).FirstOrDefault<T>();
            }
        }
        public virtual T FirstOrDefault<S>(Expression<Func<T, bool>> whereLambds, bool isAsc, Func<T, S> orderByLambds)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var temp = db.Set<T>().AsNoTracking().Where<T>(whereLambds);
                if (isAsc)
                {
                    return temp.OrderBy<T, S>(orderByLambds).FirstOrDefault<T>();
                }
                else
                {
                    return temp.OrderByDescending<T, S>(orderByLambds).FirstOrDefault<T>();
                }
            }
        }
        /// <summary>
        /// 全量
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> Get()
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.Set<T>().AsNoTracking().ToList<T>();
            }
        }

        /// <summary>
        /// 带条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IList<T> Get(Expression<Func<T, bool>> where)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.Set<T>().AsNoTracking().Where<T>(where).ToList<T>();
            }
        }
        /// <summary>
        /// 带条件+子表查询
        /// </summary>
        /// <param name="where"></param>
        /// <param name="lstSubSetType"></param>
        /// <returns></returns>
        public virtual IList<T> Get(Expression<Func<T, bool>> where, params Type[] lstSubSetType)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                DbSet<T> dbSet = db.Set<T>();
                IQueryable<T> query = null;
                if (lstSubSetType != null && lstSubSetType.Any())
                {
                    foreach (var item in lstSubSetType)
                    {
                        query = query == null
                            ? dbSet.Include(item.Name)
                            : query.Include(item.Name);
                    }
                }
                return (query ?? dbSet).AsNoTracking().Where<T>(where).ToList<T>();
            }
        }
        /// <summary>
        /// 带排序查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambds"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderByLambds"></param>
        /// <returns></returns>
        public virtual IList<T> Get<S>(Expression<Func<T, bool>> whereLambds, bool isAsc, Func<T, S> orderByLambds)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var temp = db.Set<T>().AsNoTracking().Where<T>(whereLambds);
                if (isAsc)
                {
                    return temp.OrderBy<T, S>(orderByLambds).ToList<T>();
                }
                else
                {
                    return temp.OrderByDescending<T, S>(orderByLambds).ToList<T>();
                }
            }
        }
        /// <summary>
        /// 带分页查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rows"></param>
        /// <param name="totalPage"></param>
        /// <param name="whereLambds"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderByLambds"></param>
        /// <returns></returns>
        public virtual IList<T> Get<S>(int pageIndex, int pageSize, out int rows, out int totalPage, Expression<Func<T, bool>> whereLambds, bool isAsc, Expression<Func<T, S>> orderByLambds)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                var temp = db.Set<T>().Where<T>(whereLambds).AsNoTracking();
#if DEBUG
                string sql = temp.ToString();
#endif
                rows = temp.Count();
                if (rows % pageSize == 0)
                {
                    totalPage = rows / pageSize;
                }
                else
                {
                    totalPage = rows / pageSize + 1;
                }
                if (isAsc)
                {
                    temp = temp.OrderBy<T, S>(orderByLambds);
                }
                else
                {
                    temp = temp.OrderByDescending<T, S>(orderByLambds);
                }

                temp = temp.Skip<T>(pageSize * pageIndex).Take<T>(pageSize);
#if DEBUG
                string sql1 = temp.ToString();
#endif
                return temp.ToList<T>();
            }
        }
        /// <summary>
        /// 传统sql结合EF分页实现查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rows"></param>
        /// <param name="totalPage"></param>
        /// <param name="sql"></param>
        /// <param name="where"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderKey"></param>
        /// <returns></returns>
        public virtual IList<T> Get(int pageIndex, int pageSize, out int rows, out int totalPage, string sql, string where, bool isAsc, string orderKey)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                sql = sql + " where 1=1 " + where;
                sql += " order by " + orderKey;
                if (!isAsc)
                {
                    sql += " desc";
                }
                var temp = db.Database.SqlQuery<T>(sql);
                rows = temp.Count();
                if (rows % pageSize == 0)
                {
                    totalPage = rows / pageSize;
                }
                else
                {
                    totalPage = rows / pageSize + 1;
                }
                return temp.Skip(pageSize * pageIndex).Take(pageSize).ToList();
            }
        }
        #endregion


        #region Add
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                // db.Entry<T>(entity).State = EntityState.Added;//此方法同下方法
                db.Set<T>().Add(entity);
                db.SaveChanges();
                return entity;//因为可能要返回自动增长的ID，所以把整个实体返回，否则可以直接返回bool。
            }
        }

        /// <summary>
        /// 同时增加多条数据到一张表
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual bool Add(IList<T> entitys)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                foreach (var entity in entitys)
                {
                    db.Entry<T>(entity).State = EntityState.Added;
                }
                // entitys.ForEach(c=>db.Entry<T>(c).State = EntityState.Added);//等价于上面的循环
                return db.SaveChanges() > 0;
            }
        }
        #endregion

        public virtual void AddOrUpdate(Expression<Func<T, object>> identifierExpression, params T[] entities)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                db.Set<T>().AddOrUpdate(identifierExpression, entities);
                db.SaveChanges();
            }
        }

        #region Edit
        /// <summary>
        /// 修改一条数据，会修改所有列的值，没有赋值的属性将会被赋予属性类型的默认值**************
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Edit(T entity)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                db.Set<T>().Attach(entity);
                db.Entry<T>(entity).State = EntityState.Modified;//将所有属性标记为修改状态
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 修改多条数据到一张表
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual int Edit(IList<T> entitys)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                foreach (var entity in entitys)
                {
                    db.Set<T>().Attach(entity);
                    db.Entry<T>(entity).State = EntityState.Modified;//将所有属性标记为修改状态
                }
                return db.SaveChanges();
            }
        }

        #endregion

        #region Delete
        /// <summary>
        /// 删除一个实体对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                db.Set<T>().Attach(entity);
                db.Entry<T>(entity).State = EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
        /// <summary>
        /// 删除多个实体对象
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual int Delete(IList<T> entitys)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                foreach (var entity in entitys)
                {
                    db.Set<T>().Attach(entity);
                    db.Entry<T>(entity).State = EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual int Delete(Expression<Func<T, bool>> where)
        {
            using (FacePlatformDB db = new FacePlatformDB())
            {
                return db.Set<T>().Where(where).Delete();
            }
        }
        #endregion


    }
}
