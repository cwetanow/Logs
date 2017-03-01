using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logs.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int EntryId { get; set; }

        [ForeignKey("EntryId")]
        public LogEntry Entry { get; set; }

        public string Content { get; set; }
    }
}
