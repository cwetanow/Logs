﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logs.Models
{
    public class Vote
    {
        [Key]
        public int LogVoteId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int LogId { get; set; }

        [ForeignKey("LogId")]
        public virtual TrainingLog Log { get; set; }
    }
}
