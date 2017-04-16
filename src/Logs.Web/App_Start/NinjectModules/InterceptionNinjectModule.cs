using Logs.Services;
using Logs.Web.Infrastructure.Interception;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace Logs.Web.App_Start.NinjectModules
{
    public class InterceptionNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<CachingInterceptor>().ToSelf();

            this.AddInterceptions();
        }

        private void AddInterceptions()
        {
            Kernel.AddMethodInterceptor(typeof(LogsService).GetMethod("GetAllSortedByDate"), Kernel.Get<CachingInterceptor>().Intercept);
        }
    }
}