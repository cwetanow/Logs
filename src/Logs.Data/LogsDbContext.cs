using System.Data.Entity;
using Logs.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logs.Data
{
    public class LogsDbContext : IdentityDbContext<User>
    {
        public LogsDbContext()
            : base("LogsDb", throwIfV1Schema: false)
        {
            this.Database.CreateIfNotExists();
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
                .HasRequired(log => log.User)
                .WithRequiredDependent();

            base.OnModelCreating(modelBuilder);
        }
    }
}
