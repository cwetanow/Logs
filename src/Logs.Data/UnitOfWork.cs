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
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public async void CommitAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
