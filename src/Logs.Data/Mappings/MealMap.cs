using System.Data.Entity.ModelConfiguration;
using Logs.Models;

namespace Logs.Data.Mappings
{
    public class MealMap : EntityTypeConfiguration<Meal>
    {
        public MealMap()
        {
            // Primary Key
            this.HasKey(t => t.MealId);

            // Table & Column Mappings
            this.ToTable("Meals");
            this.Property(t => t.MealId).HasColumnName("MealId");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.EntryId).HasColumnName("EntryId");

            // Relationships
            this.HasRequired(t => t.NutritionEntry)
                .WithMany(t => t.Meals)
                .HasForeignKey(d => d.EntryId);

        }
    }
}
