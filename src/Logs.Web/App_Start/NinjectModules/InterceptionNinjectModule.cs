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
            this.Bind<CachingInterceptor>().ToSelf().InSingletonScope();

            this.AddInterceptions();
        }

        private void AddInterceptions()
        {
            var cachingInterceptor = this.Kernel.Get<CachingInterceptor>();

            Kernel.AddMethodInterceptor(typeof(LogsService).GetMethod("GetAllSortedByDate"), cachingInterceptor.Intercept);
            Kernel.AddMethodInterceptor(typeof(NutritionService).GetMethod("GetUserNutritionsSortedByDate"), cachingInterceptor.Intercept);
            Kernel.AddMethodInterceptor(typeof(MeasurementService).GetMethod("GetUserMeasurementsSortedByDate"), cachingInterceptor.Intercept);
        }
    }
}