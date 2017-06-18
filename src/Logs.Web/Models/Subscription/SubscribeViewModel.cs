namespace Logs.Web.Models.Subscription
{
    public class SubscribeViewModel
    {
        public SubscribeViewModel()
        {

        }

        public SubscribeViewModel(bool isSubscribed, int logId)
        {
            this.IsSubscribed = isSubscribed;
            this.LogId = logId;
        }

        public bool IsSubscribed { get; set; }

        public int LogId { get; set; }
    }
}