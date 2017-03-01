using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logs.Models
{
    public class TrainingLog
    {
        public TrainingLog()
        {
            this.Votes = new HashSet<Vote>();
            this.Entries = new HashSet<LogEntry>();
        }

        [Key]
        public int LogId { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public ICollection<LogEntry> Entries { get; set; }
    }
}
