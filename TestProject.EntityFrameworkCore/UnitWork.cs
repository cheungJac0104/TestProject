﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using TestProject.Infrastructure;
using Z.EntityFramework.Plus;

namespace TestProject.EntityFrameworkCore
{
    public class UnitWork : IUnitWork
    {
        private TPTDBContext _context;

        public UnitWork(TPTDBContext context)
        {
            _context = context;
        }
        public TPTDBContext GetDbContext()
        {
            return _context;
        }

        /// <summary>
        /// 根据过滤条件，获取记录
        /// </summary>
        /// <param name="exp">The exp.</param>
        public IQueryable<T> Find<T>(Expression<Func<T, bool>> exp = null) where T : class
        {
            return Filter(exp);
        }

        public bool IsExist<T>(Expression<Func<T, bool>> exp) where T : class
        {
            return _context.Set<T>().Any(exp);
        }
        /// <summary>
        /// 查找单个，被上下文所跟踪
        /// </summary>
        public T FindSingleTracking<T>(Expression<Func<T, bool>> exp) where T : class
        {
            return _context.Set<T>().FirstOrDefault(exp);
        }
        /// <summary>
        /// 查找单个
        /// </summary>
        public T FindSingle<T>(Expression<Func<T, bool>> exp) where T : class
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(exp);
        }
        /// <summary>
        /// 指定实体不跟踪
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Detached<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Detached;
        }


        /// <summary>
        /// 得到分页记录
        /// </summary>
        /// <param name="orderby">排序，格式如："Id"/"Id descending"</param>
        public IQueryable<T> Find<T>(int pageindex, int pagesize, string orderby = "", Expression<Func<T, bool>> exp = null) where T : class
        {
            if (pageindex < 1) pageindex = 1;
            if (string.IsNullOrEmpty(orderby))
                orderby = "Id descending";

            return Filter(exp).OrderBy(orderby).Skip(pagesize * (pageindex - 1)).Take(pagesize);

        }

        /// <summary>
        /// 根据过滤条件获取记录数
        /// </summary>
        public int GetCount<T>(Expression<Func<T, bool>> exp = null) where T : class
        {
            return Filter(exp).Count();
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void BatchAdd<T>(List<T> entities) where T : class
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Update<T>(T entity) where T : class
        {
            var entry = this._context.Entry(entity);
            entry.State = EntityState.Modified;

            //如果数据没有发生变化
            if (!this._context.ChangeTracker.HasChanges())
            {
                entry.State = EntityState.Unchanged;
            }

        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// 实现按需要只更新部分更新
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="entity">The entity.</param>
        public void Update<T>(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity) where T : class
        {
            _context.Set<T>().Where(where).Update(entity);
        }

        public virtual void Delete<T>(Expression<Func<T, bool>> exp) where T : class
        {
            _context.Set<T>().RemoveRange(Filter(exp));
        }

        public void Save()
        {
            try
            {
                var entities = _context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added
                                || e.State == EntityState.Modified)
                    .Select(e => e.Entity);

                foreach (var entity in entities)
                {
                    var validationContext = new ValidationContext(entity);
                    Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
                }

                _context.SaveChanges();
            }
            catch (ValidationException exc)
            {
                Console.WriteLine($"{nameof(Save)} validation exception: {exc?.Message}");
                throw (exc.InnerException as Exception ?? exc);
            }
            catch (Exception ex) //DbUpdateException 
            {
                throw (ex.InnerException as Exception ?? ex);
            }

        }

        private IQueryable<T> Filter<T>(Expression<Func<T, bool>> exp) where T : class
        {
            var dbSet = _context.Set<T>().AsNoTracking().AsQueryable();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }

        public int ExecuteSql(string sql)
        {
            return _context.Database.ExecuteSqlRaw(sql);
        }

        public IQueryable<T> FromSql<T>(string sql, params object[] parameters) where T : class
        {
            return _context.Set<T>().FromSqlRaw(sql, parameters);
        }

        public IQueryable<T> Query<T>(string sql, params object[] parameters) where T : class
        {
            return _context.Set<T>().FromSqlRaw(sql, parameters);
        }
    }
}