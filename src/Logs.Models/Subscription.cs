namespace Logs.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }

        public string UserId { get; set; }

        public int TrainingLogId { get; set; }

        public virtual User User { get; set; }

        public virtual TrainingLog TrainingLog { get; set; }
    }
}
