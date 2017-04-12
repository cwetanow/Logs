using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Logs.Models.Enumerations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logs.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Entries = new HashSet<LogEntry>();
            this.NutritionEntries = new HashSet<Nutrition>();
        }

        public User(string username, string email)
            : this()
        {
            this.UserName = username;
            this.Email = email;
        }

        public GenderType GenderType { get; set; }

        [Range(0.0, 500)]
        public double Weight { get; set; }

        [Range(0, 200)]
        public int Age { get; set; }

        [Range(0.0, 100)]
        public double BodyFatPercent { get; set; }

        [Range(0.0, 500.0)]
        public int Height { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public virtual TrainingLog Log { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Nutrition> NutritionEntries { get; set; }

        public virtual ICollection<LogEntry> Entries { get; set; }

        public string ProfileImageUrl { get; set; }
    }
}
