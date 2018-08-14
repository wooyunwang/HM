using HM.FacePlatform.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace HM.FacePlatform.BLL
{
    /// <summary>
    /// 基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseBLL<T> where T : class, new()
    {
        protected BaseDAL<T> dal = new BaseDAL<T>();

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <returns></returns>
        public virtual bool Any()
        {
            return dal.Any();
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return dal.Any(where);
        }

        #region Add
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            return dal.Add(entity);
        }
        /// <summary>
        /// 同时增加多条数据到一张表（事务处理）
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual bool Add(IList<T> entitys)
        {
            return dal.Add(entitys);
        }
        #endregion

        public virtual void AddOrUpdate(Expression<Func<T, object>> identifierExpression, params T[] entities)
        {
            dal.AddOrUpdate(identifierExpression, entities);
        }

        #region Edit
        /// <summary>
        /// 修改一条数据，会修改所有列的值，没有赋值的属性将会被赋予属性类型的默认值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Edit(T entity)
        {
            return dal.Edit(entity);
        }

        /// <summary>
        /// 修改多条数据，会修改所有列的值，没有赋值的属性将会被赋予属性类型的默认值
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual int Edit(IList<T> entitys)
        {
            return dal.Edit(entitys);
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
            return dal.Delete(entity);
        }
        /// <summary>
        /// 删除多个实体对象
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual int Delete(IList<T> entitys)
        {
            return dal.Delete(entitys);
        }
        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual int Delete(Expression<Func<T, bool>> where)
        {
            return dal.Delete(where);
        }
        #endregion

        #region Get AsNoTracking
        /// <summary>
        /// 带条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return dal.FirstOrDefault(where);
        }
        public virtual T FirstOrDefault<S>(Expression<Func<T, bool>> whereLambds, bool isAsc, Func<T, S> orderByLambds)
        {
            return dal.FirstOrDefault(whereLambds, isAsc, orderByLambds);
        }
        /// <summary>
        /// 全量
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> Get()
        {
            return dal.Get();
        }
        /// <summary>
        /// 带条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IList<T> Get(Expression<Func<T, bool>> where)
        {
            return dal.Get(where);
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
            return dal.Get(whereLambds, isAsc, orderByLambds);
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
            return dal.Get(pageIndex, pageSize, out rows, out totalPage, whereLambds, isAsc, orderByLambds);
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
            return dal.Get(pageIndex, pageSize, out rows, out totalPage, sql, where, isAsc, orderKey);
        }
        #endregion
    }
}
