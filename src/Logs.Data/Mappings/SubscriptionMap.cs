using Logs.Models;
using System.Data.Entity.ModelConfiguration;

namespace Logs.Data.Mappings
{
    public class SubscriptionMap : EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.SubscriptionId);

            // Properties
            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Subscriptions");
            this.Property(t => t.SubscriptionId).HasColumnName("SubscriptionId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.TrainingLogId).HasColumnName("TrainingLogId");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(d => d.UserId);
            this.HasRequired(t => t.TrainingLog)
                .WithMany(t => t.Subscriptions)
                .HasForeignKey(d => d.TrainingLogId);
        }
    }
}
