using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Logs.Data.Contracts;

namespace Logs.Data
{
    public class EfGenericRepository<T> : IRepository<T>
          where T : class
    {
        private readonly ILogsDbContext dbContext;

        public EfGenericRepository(ILogsDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext cannot be null");
            }

            this.dbContext = dbContext;
        }

        protected IQueryable<T> Entities
        {
            get { return this.dbContext.Set<T>(); }
        }

        public IEnumerable<T> GetPaged<T1>(Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, T1>> sortExpression,
            int page,
            int count,
            bool descending)
        {
            var result = this.Entities;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (sortExpression != null)
            {
                if (descending)
                {
                    result = result.OrderByDescending(sortExpression);
                }
                else
                {
                    result = result.OrderBy(sortExpression);
                }
            }

            result = result.Skip((page - 1) * count)
                .Take(count);

            return result.ToList();
        }

        public void Add(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return this.Entities
                .ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return this.Entities
                   .Where(filterExpression)
                   .ToList();
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression)
        {
            return this.Entities
                   .Where(filterExpression)
                   .OrderBy(sortExpression)
                   .ToList();
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression)
        {
            return this.Entities
                  .Where(filterExpression)
                  .OrderBy(sortExpression)
                  .Select(selectExpression)
                   .ToList();
        }

        public T GetById(object id)
        {
            return this.dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
