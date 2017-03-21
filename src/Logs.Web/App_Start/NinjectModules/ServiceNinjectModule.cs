using Logs.Services;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Interception;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace Logs.Web.App_Start.NinjectModules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ILogService>().To<LogsService>();
            this.Bind<IEntryService>().To<EntryService>();
            this.Bind<IUserService>().To<UserService>();
            this.Bind<IVoteService>().To<VoteService>();
            this.Bind<ICommentService>().To<CommentService>();

            this.Bind<CachingInterceptor>().ToSelf();

            Kernel.AddMethodInterceptor(typeof(LogsService).GetMethod("GetAllSortedByDate"), Kernel.Get<CachingInterceptor>().Intercept);
        }
    }
}