using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Logs.Data.Contracts;

namespace Logs.Data
{
    public class GenericRepository<T> : IRepository<T>
          where T : class
    {
        private readonly ILogsDbContext dbContext;

        public GenericRepository(ILogsDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        public IQueryable<T> All
        {
            get
            {
                return this.dbContext.DbSet<T>();
            }
        }

        public void Add(T entity)
        {
            this.dbContext.SetAdded(entity);
        }

        public void Delete(T entity)
        {
            this.dbContext.SetDeleted(entity);
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, bool isDescending)
        {
            var result = this.dbContext
                .DbSet<T>()
                .Where(filterExpression);

            if (isDescending)
            {
                result = result.OrderByDescending(sortExpression);
            }
            else
            {
                result = result.OrderBy(sortExpression);
            }

            return result.ToList();
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression)
        {
            return this.dbContext
                .DbSet<T>()
                .Where(filterExpression)
                .OrderBy(sortExpression)
                .Select(selectExpression)
                .ToList();
        }

        public T GetById(object id)
        {
            return this.dbContext.DbSet<T>().Find(id);
        }

        public void Update(T entity)
        {
            this.dbContext.SetUpdated(entity);
        }
    }
}
