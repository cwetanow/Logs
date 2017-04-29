using System;

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

        public int CommentId { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public int EntryId { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }

        public virtual LogEntry LogEntry { get; set; }
    }
}
