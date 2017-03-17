using System;
using Logs.Models;

namespace Logs.Web.Areas.Administration.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {

        }

        public UserViewModel(User user, bool isAdmin)
        {
            this.Username = user.UserName;
            this.LockoutEndDateUtc = user.LockoutEndDateUtc;
            this.Email = user.Email;
            this.ProfileImageUrl = user.ProfileImageUrl;
            this.UserId = user.Id;
            this.IsAdministrator = isAdmin;
        }

        public string UserId { get; set; }

        public string Email { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public string Username { get; set; }

        public string ProfileImageUrl { get; set; }

        public bool IsAdministrator { get; set; }
    }
}