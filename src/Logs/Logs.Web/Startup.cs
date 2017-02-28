using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Logs.Web.Startup))]
namespace Logs.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
