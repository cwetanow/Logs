using Logs.Authentication;
using Logs.Authentication.Contracts;
using Ninject.Modules;

namespace Logs.Web.App_Start.NinjectModules
{
    public class AuthNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAuthenticationProvider>().To<AuthenticationProvider>().InSingletonScope();
        }
    }
}