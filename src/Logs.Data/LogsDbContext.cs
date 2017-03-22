using System.Data.Entity;
using Logs.Data.Contracts;
using Logs.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logs.Data
{
    public class LogsDbContext : IdentityDbContext<User>, ILogsDbContext
    {
        public LogsDbContext()
            : base("LogsDb", throwIfV1Schema: false)
        {
            this.Database.CreateIfNotExists();

            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public static LogsDbContext Create()
        {
            return new LogsDbContext();
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<LogEntry> Entries { get; set; }

        public DbSet<TrainingLog> Logs { get; set; }

        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingLog>()
                .HasOptional(log => log.User)
                .WithOptionalDependent();

            Database.SetInitializer<LogsDbContext>(null);

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        public void SetAdded<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void SetDeleted<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public void SetUpdated<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
