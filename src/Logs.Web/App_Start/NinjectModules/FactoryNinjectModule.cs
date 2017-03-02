using Logs.Factories;
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
        }
    }
}