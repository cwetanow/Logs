using System.Data.Entity.ModelConfiguration;
using Logs.Models;

namespace Logs.Data.Mappings
{
    public class NutritionEntryMap : EntityTypeConfiguration<NutritionEntry>
    {
        public NutritionEntryMap()
        {
            // Primary Key
            this.HasKey(t => t.NutritionEntryId);

            // Properties
            this.Property(t => t.UserId)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("NutritionEntries");
            this.Property(t => t.NutritionEntryId).HasColumnName("NutritionEntryId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.MeasurementsId).HasColumnName("MeasurementsId");
            this.Property(t => t.NutritionId).HasColumnName("NutritionId");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.NutritionEntries)
                .HasForeignKey(d => d.UserId);

            this.HasOptional(t => t.Measurement)
                .WithMany(t => t.NutritionEntries)
                .HasForeignKey(d => d.MeasurementsId);

            this.HasOptional(t => t.Nutrition)
                .WithMany(t => t.NutritionEntries)
                .HasForeignKey(d => d.NutritionId);

        }
    }
}
