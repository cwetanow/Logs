using Logs.Factories;
using Logs.Web.Infrastructure.Factories;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Logs.Web.App_Start.NinjectModules
{
    public class FactoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITrainingLogFactory>().ToFactory().InSingletonScope();
            this.Bind<IUserFactory>().ToFactory().InSingletonScope();
            this.Bind<ILogEntryFactory>().ToFactory().InSingletonScope();
            this.Bind<ICommentFactory>().ToFactory().InSingletonScope();
            this.Bind<IVoteFactory>().ToFactory().InSingletonScope();

            this.Bind<IViewModelFactory>().ToFactory().InSingletonScope();
        }
    }
}