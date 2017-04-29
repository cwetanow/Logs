using System.Data.Entity.ModelConfiguration;
using Logs.Models;

namespace Logs.Data.Mappings
{
    public class MeasurementMap : EntityTypeConfiguration<Measurement>
    {
        public MeasurementMap()
        {
            // Primary Key
            this.HasKey(t => t.MeasurementsId);

            // Table & Column Mappings
            this.ToTable("Measurements");
            this.Property(t => t.MeasurementsId).HasColumnName("MeasurementsId");
            this.Property(t => t.Heigh).HasColumnName("Heigh");
            this.Property(t => t.WeightKg).HasColumnName("WeightKg");
            this.Property(t => t.BodyFatPercent).HasColumnName("BodyFatPercent");
            this.Property(t => t.Chest).HasColumnName("Chest");
            this.Property(t => t.Shoulders).HasColumnName("Shoulders");
            this.Property(t => t.Forearm).HasColumnName("Forearm");
            this.Property(t => t.Arm).HasColumnName("Arm");
            this.Property(t => t.Waist).HasColumnName("Waist");
            this.Property(t => t.Hips).HasColumnName("Hips");
            this.Property(t => t.Thighs).HasColumnName("Thighs");
            this.Property(t => t.Calves).HasColumnName("Calves");
            this.Property(t => t.Neck).HasColumnName("Neck");
            this.Property(t => t.Wrist).HasColumnName("Wrist");
            this.Property(t => t.Ankle).HasColumnName("Ankle");
            this.Property(t => t.NutritionEntryId).HasColumnName("NutritionEntryId");
        }
    }
}
