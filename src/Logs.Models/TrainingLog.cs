using System;
using System.Collections.Generic;

namespace Logs.Models
{
    public class TrainingLog
    {
        public TrainingLog()
        {
            this.Users = new HashSet<User>();
            this.LogEntries = new HashSet<LogEntry>();
            this.Votes = new HashSet<Vote>();
        }

        public TrainingLog(string name, string description, DateTime dateCreated, User user)
            : this()
        {
            this.Name = name;
            this.Description = description;
            this.DateCreated = dateCreated;
            this.User = user;
            this.User.TrainingLog = this;
            this.Owner = user.UserName;

            this.LastEntryDate = this.DateCreated;
            this.LastActivityUser = this.User.UserName;
        }

        public int LogId { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string LastActivityUser { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastEntryDate { get; set; }

        public int? LastEntryId { get; set; }

        public string UserId { get; set; }

        public string Owner { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<LogEntry> LogEntries { get; set; }

        public virtual LogEntry LastLogEntry { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
