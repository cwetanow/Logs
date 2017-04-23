using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Logs.Models;

namespace Logs.Web.Models.Logs
{
    public class CommentViewModel
    {
        public static Func<Comment, string, bool, CommentViewModel> FromComment
        {
            get
            {
                return (comment, userId, isAdmin) => new CommentViewModel
                {
                    Date = comment.Date,
                    CanEdit = comment.UserId.Equals(userId) || isAdmin,
                    CommentId = comment.CommentId,
                    Content = comment.Content,
                    User = comment.User.UserName
                };
            }
        }

        public bool CanEdit { get; set; }

        public int CommentId { get; set; }

        public DateTime Date { get; set; }

        public string User { get; set; }

        [AllowHtml]
        [Required]
        public string Content { get; set; }
    }
}