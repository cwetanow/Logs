namespace Logs.Web.Models.Navigation
{
    public class NavigationViewModel
    {
        public NavigationViewModel()
        {
            
        }

        public NavigationViewModel(string username, bool isAuthenticated, bool isAdmin)
        {
            this.Username = username;
            this.IsAuthenticated = isAuthenticated;
            this.IsAdmin = isAdmin;
        }

        public bool IsAuthenticated { get; set; }

        public string Username { get; set; }

        public bool IsAdmin { get; set; }
    }
}