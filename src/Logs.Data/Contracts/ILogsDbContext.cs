using System.Data.Entity;

namespace Logs.Data.Contracts
{
    public interface ILogsDbContext
    {
        IDbSet<TEntity> DbSet<TEntity>()
            where TEntity : class;

        int SaveChanges();

        void SetAdded<TEntry>(TEntry entity)
            where TEntry : class;

        void SetDeleted<TEntry>(TEntry entity)
            where TEntry : class;

        void SetUpdated<TEntry>(TEntry entity)
            where TEntry : class;
    }
}
