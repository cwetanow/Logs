using System.IO;
using System.Reflection;
using Logs.Data;
using Logs.Data.Contracts;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Logs.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ILogsDbContext>().To<LogsDbContext>().InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
        }
    }
}