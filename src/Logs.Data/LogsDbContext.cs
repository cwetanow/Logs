using System.Data.Entity;
using Logs.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logs.Data
{
    public class LogsDbContext : IdentityDbContext<User>
    {
        public LogsDbContext()
            : base("LogsDb", throwIfV1Schema: false)
        {
            this.Database.CreateIfNotExists();
        }

        public static LogsDbContext Create()
        {
            return new LogsDbContext();
        }
    }
}
