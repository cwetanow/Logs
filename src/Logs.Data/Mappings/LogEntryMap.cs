using System.Data.Entity.ModelConfiguration;
using Logs.Models;

namespace Logs.Data.Mappings
{
    public class LogEntryMap : EntityTypeConfiguration<LogEntry>
    {
        public LogEntryMap()
        {
            // Primary Key
            this.HasKey(t => t.LogEntryId);

            // Properties
            this.Property(t => t.UserId)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("LogEntries");
            this.Property(t => t.LogEntryId).HasColumnName("LogEntryId");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.LogId).HasColumnName("LogId");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.LogEntries)
                .HasForeignKey(d => d.UserId);

            this.HasOptional(t => t.TrainingLog)
                .WithMany(t => t.LogEntries)
                .HasForeignKey(d => d.LogId);

        }
    }
}
