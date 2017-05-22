using System.Data.Entity.ModelConfiguration;
using Logs.Models;

namespace Logs.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("AspNetUsers");
            this.Property(t => t.LogId).HasColumnName("LogId");
            this.Property(t => t.GenderType).HasColumnName("GenderType");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.Age).HasColumnName("Age");
            this.Property(t => t.BodyFatPercent).HasColumnName("BodyFatPercent");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ProfileImageUrl).HasColumnName("ProfileImageUrl");

            // Relationships
            this.HasOptional(t => t.TrainingLog)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.LogId);
        }
    }
}
