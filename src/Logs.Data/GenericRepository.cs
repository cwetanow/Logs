﻿using System;
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
