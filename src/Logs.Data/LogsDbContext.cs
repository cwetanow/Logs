using System.Data.Entity;
using Logs.Data.Contracts;
using Logs.Data.Mappings;
using Logs.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logs.Data
{
    public class LogsDbContext : IdentityDbContext<User>, ILogsDbContext
    {
        public LogsDbContext()
            : base("LogsDb", throwIfV1Schema: false)
        {
            Database.SetInitializer<LogsDbContext>(null);

            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public static LogsDbContext Create()
        {
            return new LogsDbContext();
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<LogEntry> LogEntries { get; set; }

        public DbSet<Measurement> Measurements { get; set; }

        public DbSet<Nutrition> Nutritions { get; set; }

        public DbSet<TrainingLog> TrainingLogs { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new LogEntryMap());
            modelBuilder.Configurations.Add(new MeasurementMap());
            modelBuilder.Configurations.Add(new NutritionMap());
            modelBuilder.Configurations.Add(new TrainingLogMap());
            modelBuilder.Configurations.Add(new VoteMap());
            modelBuilder.Configurations.Add(new SubscriptionMap());
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
