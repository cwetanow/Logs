namespace Logs.Web.Models.Home
{
    public class HomeViewModel
    {
        public HomeViewModel(bool isAuthenticated)
        {
            this.IsAuthenticated = isAuthenticated;
        }

        public bool IsAuthenticated { get; set; }
    }
}