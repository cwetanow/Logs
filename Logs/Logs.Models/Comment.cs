using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logs.Models
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(string content, DateTime date, User user)
        {
            this.Content = content;
            this.Date = date;
            this.User = user;
        }

        [Key]
        public int CommentId { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int EntryId { get; set; }

        [ForeignKey("EntryId")]
        public virtual LogEntry Entry { get; set; }

        public string Content { get; set; }
    }
}
