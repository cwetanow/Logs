using System;
using System.Collections.Generic;

namespace Logs.Models
{
    public class LogEntry
    {
        public LogEntry()
        {
            this.Comments = new HashSet<Comment>();
            this.TrainingLogs = new HashSet<TrainingLog>();
        }

        public LogEntry(string content, DateTime entryDate, int logId)
            : this()
        {
            this.Content = content;
            this.EntryDate = entryDate;
            this.LogId = logId;
        }

        public int LogEntryId { get; set; }

        public DateTime EntryDate { get; set; }

        public string Content { get; set; }

        public int? LogId { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual TrainingLog TrainingLog { get; set; }

        public virtual ICollection<TrainingLog> TrainingLogs { get; set; }
    }
}
