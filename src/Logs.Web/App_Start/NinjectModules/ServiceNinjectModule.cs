﻿using Logs.Services;
using Logs.Services.Contracts;
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
        }
    }
}