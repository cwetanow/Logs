namespace Logs.Models
{
    public class Vote
    {
        public Vote()
        {
            
        }

        public Vote(int logId, string userId)
        {
            this.LogId = logId;
            this.UserId = userId;
        }

        public int LogVoteId { get; set; }

        public string UserId { get; set; }

        public int LogId { get; set; }

        public virtual User User { get; set; }

        public virtual TrainingLog TrainingLog { get; set; }
    }
}
