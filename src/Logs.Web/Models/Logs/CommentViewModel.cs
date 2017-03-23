using System;
using Logs.Models;

namespace Logs.Web.Models.Logs
{
    public class CommentViewModel
    {
        public static Func<Comment, string, CommentViewModel> FromComment
        {
            get
            {
                return (comment, userId) => new CommentViewModel
                {
                    Date = comment.Date,
                    CanEdit = comment.UserId.Equals(userId),
                    CommentId = comment.CommentId,
                    Content = comment.Content,
                    User = comment.User.UserName
                };
            }
        }

        public CommentViewModel()
        {

        }

        public bool CanEdit { get; set; }

        public int CommentId { get; set; }

        public DateTime Date { get; set; }

        public string User { get; set; }

        public string Content { get; set; }
    }
}