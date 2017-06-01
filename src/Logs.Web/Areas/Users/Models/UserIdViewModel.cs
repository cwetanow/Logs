namespace Logs.Web.Areas.Users.Models
{
    public class UserIdViewModel
    {
        public UserIdViewModel(string userId)
        {
            this.UserId = userId;
        }

        public UserIdViewModel()
        {

        }

        public string UserId { get; set; }
    }
}