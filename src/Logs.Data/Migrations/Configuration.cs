using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logs.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Logs.Data.LogsDbContext>
    {
        private const string AdminRoleName = "administrator";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Logs.Data.LogsDbContext context)
        {
            if (!context.Roles.Any(r => r.Name.Equals(AdminRoleName)))
            {
                context.Roles.Add(new IdentityRole(AdminRoleName));
            }
        }
    }
}
