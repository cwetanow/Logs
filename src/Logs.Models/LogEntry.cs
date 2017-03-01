using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logs.Models
{
    public class LogEntry
    {
        public LogEntry()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int LogEntryId { get; set; }

        public DateTime EntryDate { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int LogId { get; set; }

        [ForeignKey("LogId")]
        public virtual TrainingLog Log { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string Content { get; set; }
    }
}
