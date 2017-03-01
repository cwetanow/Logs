using System;
using Logs.Data.Contracts;

namespace Logs.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogsDbContext dbContext;

        public UnitOfWork(ILogsDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext cannot be null");
            }

            this.dbContext = dbContext;
        }

        public void Dispose()
        {

        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
