namespace Logs.Models
{
    public class Subscription
    {
        public Subscription()
        {

        }

        public Subscription(int logId, string userId)
        {
            this.UserId = userId;
            this.TrainingLogId = logId;
        }

        public int SubscriptionId { get; set; }

        public string UserId { get; set; }

        public int TrainingLogId { get; set; }

        public virtual User User { get; set; }

        public virtual TrainingLog TrainingLog { get; set; }
    }
}
