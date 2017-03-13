using System;
using Logs.Models;

namespace Logs.Web.Models.Logs
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {

        }

        public CommentViewModel(Comment comment, string userId)
        {
            this.Date = comment.Date;
            this.User = comment.User.UserName;
            this.Content = comment.Content;
            this.CommentId = comment.CommentId;
            this.CanEdit = comment.UserId.Equals(userId);
        }

        public bool CanEdit { get; set; }

        public int CommentId { get; set; }

        public DateTime Date { get; set; }

        public string User { get; set; }

        public string Content { get; set; }
    }
}