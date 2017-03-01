using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Logs.Data.Contracts
{
    public interface ILogsDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;
    }
}
