using System;
using Logs.Models;

namespace Logs.Web.Models.Logs
{
    public class CommentViewModel
    {
        public CommentViewModel(Comment comment)
        {
            this.Date = comment.Date;
            this.User = comment.User.Name;
            this.Content = comment.Content;
        }

        public DateTime Date { get; set; }

        public string User { get; set; }

        public string Content { get; set; }
    }
}