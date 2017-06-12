namespace Logs.Web.Models.Subscription
{
    public class SubscribeViewModel
    {
        public SubscribeViewModel(bool isSubscribed)
        {
            this.IsSubscribed = isSubscribed;
        }

        public bool IsSubscribed { get; set; }
    }
}