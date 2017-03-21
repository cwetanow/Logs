using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Logs.Data.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(object id);

        IQueryable<T> All { get; }

        IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, T1>> sortExpression,
            Expression<Func<T, T2>> selectExpression);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
