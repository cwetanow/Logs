using System.Data.Entity.ModelConfiguration;
using Logs.Models;

namespace Logs.Data.Mappings
{
    public class TrainingLogMap : EntityTypeConfiguration<TrainingLog>
    {
        public TrainingLogMap()
        {
            // Primary Key
            this.HasKey(t => t.LogId);

            // Properties
            this.Property(t => t.UserId)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("TrainingLogs");
            this.Property(t => t.LogId).HasColumnName("LogId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastActivityUser).HasColumnName("LastActivityUser");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.LastEntryDate).HasColumnName("LastEntryDate");
            this.Property(t => t.LastEntryId).HasColumnName("LastEntryId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Owner).HasColumnName("Owner");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.TrainingLogs)
                .HasForeignKey(d => d.UserId);

            this.HasOptional(t => t.LastLogEntry)
                .WithMany(t => t.TrainingLogs)
                .HasForeignKey(d => d.LastEntryId);

        }
    }
}
