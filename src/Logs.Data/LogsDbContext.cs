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
            Database.SetInitializer<LogsDbContext>(null);

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

        public DbSet<Nutrition> Nutritions { get; set; }

        public DbSet<Measurement> Measurements { get; set; }

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.ConfigureTrainingLogs(modelBuilder);
            this.ConfigureMeasurements(modelBuilder);
            this.ConfigureNutritions(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureTrainingLogs(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingLog>()
                .HasOptional(log => log.User)
                .WithOptionalDependent();
        }

        private void ConfigureMeasurements(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measurement>()
                 .HasKey(m => m.MeasurementId)
                 .HasRequired(m => m.User)
                 .WithMany(u => u.Measurements)
                 .HasForeignKey(m => m.UserId);
        }

        private void ConfigureNutritions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nutrition>()
               .HasKey(n => n.NutritionId)
               .HasRequired(n => n.User)
               .WithMany(u => u.NutritionEntries)
               .HasForeignKey(n => n.UserId);
        }
    }
}
