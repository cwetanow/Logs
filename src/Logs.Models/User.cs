using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        
        [Index(IsUnique = true)]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual TrainingLog Log { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<LogEntry> Entries { get; set; }
    }
}
