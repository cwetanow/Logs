using System.Linq;
using Logs.Common;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Logs.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Logs.Data.LogsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LogsDbContext context)
        {
            if (!context.Roles.Any(r => r.Name.Equals(Constants.AdministratorRoleName)))
            {
                context.Roles.Add(new IdentityRole(Constants.AdministratorRoleName));
            }
        }
    }
}
