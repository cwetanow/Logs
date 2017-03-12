using System;
using System.Web;
using System.Web.Caching;
using Logs.Services;
using Logs.Services.Contracts;
using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace Logs.Web.App_Start.NinjectModules
{
    public class ServiceNinjectModule : NinjectModule
    {
        private const string CacheItemKey = "logs";

        public override void Load()
        {
            this.Bind<ILogService>().To<LogsService>();
            this.Bind<IEntryService>().To<EntryService>();
            this.Bind<IUserService>().To<UserService>();
            this.Bind<IVoteService>().To<VoteService>();
            this.Bind<ICommentService>().To<CommentService>();

            Kernel.AddMethodInterceptor(typeof(LogsService).GetMethod("GetAllSortedByDate"), this.InterceptGetAll);
            Kernel.AddMethodInterceptor(typeof(LogsService).GetMethod("CreateTrainingLog"), this.InterceptClearCache);
        }

        private void InterceptClearCache(IInvocation obj)
        {
            HttpContext.Current.Cache.Remove(CacheItemKey);
        }

        private void InterceptGetAll(IInvocation invocation)
        {
            var result = HttpContext.Current.Cache.Get(CacheItemKey);

            if (result == null)
            {
                invocation.Proceed();

                result = invocation.ReturnValue;

                HttpContext.Current.Cache.Add(CacheItemKey,
                    result,
                    null,
                    DateTime.Now.AddMinutes(5),
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Default, null);
            }
            else
            {
                invocation.ReturnValue = result;
            }

        }
    }
}