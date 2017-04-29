using System.Data.Entity.ModelConfiguration;
using Logs.Models;

namespace Logs.Data.Mappings
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.CommentId);

            // Properties
            this.Property(t => t.UserId)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Comments");
            this.Property(t => t.CommentId).HasColumnName("CommentId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.EntryId).HasColumnName("EntryId");
            this.Property(t => t.Content).HasColumnName("Content");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.UserId);

            this.HasRequired(t => t.LogEntry)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.EntryId);

        }
    }
}
