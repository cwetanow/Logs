using System.Web.Mvc;
using Logs.Models;
using Logs.Models.Enumerations;

namespace Logs.Web.Models.Profile
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel(User user, bool canEdit)
        {
            this.HasLog = user.Log != null;
            this.LogId = this.HasLog ? user.Log.LogId : 0;
            this.Weight = user.Weight;
            this.Age = user.Age;
            this.BodyFatPercent = user.BodyFatPercent;
            this.Height = user.Height;
            this.Description = user.Description;
            this.Username = user.UserName;
            this.Email = user.Email;
            this.ProfileImageUrl = user.ProfileImageUrl;
            this.Id = user.Id;
            this.GenderType = user.GenderType;

            this.CanEdit = canEdit;
        }

        public UserProfileViewModel()
        {
            
        }

        public double Weight { get; set; }

        public int Age { get; set; }

        public double BodyFatPercent { get; set; }

        public int Height { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string ProfileImageUrl { get; set; }

        public string Id { get; set; }

        public GenderType GenderType { get; set; }

        public bool HasLog { get; set; }

        public int LogId { get; set; }

        public bool CanEdit { get; set; }
    }
}