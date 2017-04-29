using System.Collections.Generic;
using Logs.Models.Enumerations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logs.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.LogEntries = new HashSet<LogEntry>();
            this.NutritionEntries = new HashSet<NutritionEntry>();
            this.TrainingLogs = new HashSet<TrainingLog>();
            this.Votes = new HashSet<Vote>();
        }

        public User(string username, string email)
           : this()
        {
            this.UserName = username;
            this.Email = email;
        }

        public int? LogId { get; set; }

        public GenderType GenderType { get; set; }

        public double Weight { get; set; }

        public int Age { get; set; }

        public double BodyFatPercent { get; set; }

        public int Height { get; set; }

        public string Description { get; set; }

        public string ProfileImageUrl { get; set; }

        public virtual TrainingLog TrainingLog { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<LogEntry> LogEntries { get; set; }

        public virtual ICollection<NutritionEntry> NutritionEntries { get; set; }

        public virtual ICollection<TrainingLog> TrainingLogs { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
