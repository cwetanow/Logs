using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logs.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Entries = new HashSet<LogEntry>();
        }

        public string Name { get; set; }

        public int LogId { get; set; }

        [ForeignKey("LogId")]
        public TrainingLog Log { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<LogEntry> Entries { get; set; }
    }
}
