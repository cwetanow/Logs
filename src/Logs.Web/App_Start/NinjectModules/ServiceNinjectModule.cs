using Logs.Services;
using Logs.Services.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Logs.Web.App_Start.NinjectModules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ILogService>().To<LogsService>().InRequestScope();
            this.Bind<IEntryService>().To<EntryService>().InRequestScope();
            this.Bind<IUserService>().To<UserService>().InRequestScope();
            this.Bind<IVoteService>().To<VoteService>().InRequestScope();
            this.Bind<ICommentService>().To<CommentService>().InRequestScope();
            this.Bind<INutritionService>().To<NutritionService>().InRequestScope();
        }
    }
}