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

        public DbSet<Measurements> Measurements { get; set; }

        public DbSet<NutritionEntry> NutritionEntries { get; set; }

        public DbSet<Meal> Meals { get; set; }

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
            this.ConfigureNutrition(modelBuilder);
            this.ConfigureMeals(modelBuilder);
            this.ConfigureNutritionEntries(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureMeals(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .HasKey(m => m.MealId);
        }

        private void ConfigureNutrition(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nutrition>()
                .HasKey(n => n.NutritionId);
        }

        private void ConfigureNutritionEntries(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NutritionEntry>()
                .HasKey(e => e.NutritionEntryId)
                .HasOptional(e => e.User)
                .WithMany(u => u.NutritionEntries);

            modelBuilder.Entity<NutritionEntry>()
                .HasOptional(e => e.Measurements)
                .WithOptionalDependent();

            modelBuilder.Entity<NutritionEntry>()
                .HasOptional(e => e.Nutrition)
                .WithOptionalDependent();

            modelBuilder.Entity<NutritionEntry>()
                .HasMany(e => e.Meals)
                .WithRequired(m => m.Entry);
        }

        private void ConfigureMeasurements(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measurements>()
                .HasKey(m => m.MeasurementsId)
                .HasOptional(m => m.NutritionEntry)
                .WithOptionalDependent();
        }

        private void ConfigureTrainingLogs(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingLog>()
                .HasOptional(log => log.User)
                .WithOptionalDependent();
        }
    }
}
