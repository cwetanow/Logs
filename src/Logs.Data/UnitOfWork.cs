﻿using System;
using Logs.Data.Contracts;
using System.Threading.Tasks;

namespace Logs.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogsDbContext dbContext;

        public UnitOfWork(ILogsDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
