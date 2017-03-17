using Logs.Providers;
using Logs.Providers.Contracts;
using Ninject.Modules;

namespace Logs.Web.App_Start.NinjectModules
{
    public class ProvidersNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDateTimeProvider>().To<DateTimeProvider>().InSingletonScope();
        }
    }
}