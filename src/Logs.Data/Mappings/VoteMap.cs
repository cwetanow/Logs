using System.Data.Entity.ModelConfiguration;
using Logs.Models;

namespace Logs.Data.Mappings
{
    public class VoteMap : EntityTypeConfiguration<Vote>
    {
        public VoteMap()
        {
            // Primary Key
            this.HasKey(t => t.LogVoteId);

            // Properties
            this.Property(t => t.UserId)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Votes");
            this.Property(t => t.LogVoteId).HasColumnName("LogVoteId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.LogId).HasColumnName("LogId");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.Votes)
                .HasForeignKey(d => d.UserId);

            this.HasRequired(t => t.TrainingLog)
                .WithMany(t => t.Votes)
                .HasForeignKey(d => d.LogId);

        }
    }
}
