using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TestProject.EntityFrameworkCore
{
    /// <summary>
    /// 工作单元接口
    /// <para> 适合在一下情况使用:</para>
    /// <para>1 在同一事务中进行多表操作</para>
    /// <para>2 需要多表联合查询</para>
    /// </summary>
    public interface IUnitWork
    {
        TPTDBContext GetDbContext();
        T FindSingleTracking<T>(Expression<Func<T, bool>> exp = null) where T : class;
        T FindSingle<T>(Expression<Func<T, bool>> exp = null) where T : class;
        bool IsExist<T>(Expression<Func<T, bool>> exp) where T : class;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> exp = null) where T : class;

        IQueryable<T> Find<T>(int pageindex = 1, int pagesize = 10, string orderby = "",
            Expression<Func<T, bool>> exp = null) where T : class;

        int GetCount<T>(Expression<Func<T, bool>> exp = null) where T : class;

        void Add<T>(T entity) where T : class;

        void BatchAdd<T>(List<T> entities) where T : class;

        /// <summary>
        /// 更新一个实体的所有属性
        /// </summary>
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;


        /// <summary>
        /// 实现按需要只更新部分更新
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新后的实体</param>
        void Update<T>(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity) where T : class;
        /// <summary>
        /// 批量删除
        /// </summary>
        void Delete<T>(Expression<Func<T, bool>> exp) where T : class;

        void Save();

        int ExecuteSql(string sql);

        /// <summary>
        /// 使用SQL脚本查询
        /// </summary>
        /// <typeparam name="T"> T为数据库实体</typeparam>
        /// <returns></returns>
        IQueryable<T> FromSql<T>(string sql, params object[] parameters) where T : class;
        /// <summary>
        /// 使用SQL脚本查询
        /// </summary>
        /// <typeparam name="T"> T为非数据库实体，需要在DbContext中增加对应的DbQuery</typeparam>
        /// <returns></returns>
        IQueryable<T> Query<T>(string sql, params object[] parameters) where T : class;
    }
}
