using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Logs.Data.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(object id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression);

        IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, T1>> sortExpression,
            bool isDescending = false);

        IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, T1>> sortExpression,
            Expression<Func<T, T2>> selectExpression);

        IEnumerable<T> GetPaged<T1>(Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, T1>> sortExpression,
            int page,
            int count,
            bool descending = false);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
