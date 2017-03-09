using System;
using Logs.Models;

namespace Logs.Web.Models.Logs
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {
            
        }

        public CommentViewModel(Comment comment)
        {
            this.Date = comment.Date;
            this.User = comment.User.Name;
            this.Content = comment.Content;
            this.CommentId = comment.CommentId;
        }

        public int CommentId { get; set; }

        public DateTime Date { get; set; }

        public string User { get; set; }

        public string Content { get; set; }
    }
}