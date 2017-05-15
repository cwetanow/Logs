using System.Data.Entity.ModelConfiguration;
using Logs.Models;

namespace Logs.Data.Mappings
{
    public class NutritionMap : EntityTypeConfiguration<Nutrition>
    {
        public NutritionMap()
        {
            // Primary Key
            this.HasKey(t => t.NutritionId);

            // Properties
            this.Property(t => t.UserId)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Nutritions");
            this.Property(t => t.NutritionId).HasColumnName("NutritionId");
            this.Property(t => t.Calories).HasColumnName("Calories");
            this.Property(t => t.Protein).HasColumnName("Protein");
            this.Property(t => t.Carbs).HasColumnName("Carbs");
            this.Property(t => t.Fats).HasColumnName("Fats");
            this.Property(t => t.WaterInLitres).HasColumnName("WaterInLitres");
            this.Property(t => t.Fiber).HasColumnName("Fiber");
            this.Property(t => t.Sugar).HasColumnName("Sugar");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Date).HasColumnName("Date");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.Nutritions)
                .HasForeignKey(d => d.UserId);
        }
    }
}
