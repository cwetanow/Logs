using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Microsoft.AspNet.Identity;
using PagedList;

namespace Logs.Web.Controllers
{
    public class LogsController : Controller
    {
        private const string CachedLogsKey = "logs";

        private readonly ILogService logService;
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IViewModelFactory factory;

        public LogsController(ILogService logService, IAuthenticationProvider authenticationProvider, IViewModelFactory factory)
        {
            if (logService == null)
            {
                throw new ArgumentNullException(nameof(logService));
            }

            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.logService = logService;
            this.factory = factory;
            this.authenticationProvider = authenticationProvider;
        }

        public ActionResult Details(int id, int page = 1, int count = 3)
        {
            var log = this.logService.GetTrainingLogById(id);

            var isAuthenticated = this.authenticationProvider.IsAuthenticated;
            var currentUserId = this.authenticationProvider.CurrentUserId;

            var isOwner = log.User.Id.Equals(currentUserId);
            var canVote = (log.Votes
                .FirstOrDefault(v => v.UserId.Equals(currentUserId))) == null && !isOwner && isAuthenticated; ;

            if (page < 0)
            {
                page = (log.Entries.Count - 1) / count + 1;
            }

            var entries = log.Entries
                .Select(e => this.factory.CreateLogEntryViewModel(e, currentUserId))
                .ToPagedList(page, count);

            var model = this.factory.CreateLogDetailsViewModel(log, isAuthenticated, isOwner, canVote, entries);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = this.factory.CreateCreateLogViewModel();

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public RedirectToRouteResult CreateLog(CreateLogViewModel model)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var log = this.logService.CreateTrainingLog(model.Name, model.Description, userId);

            this.HttpContext.Cache[CachedLogsKey] = null;

            return this.RedirectToAction("Details", new { id = log.LogId });
        }

        public ActionResult PartialList(int count = 10, int page = 1)
        {
            var logs = this.HttpContext.Cache[CachedLogsKey] as IEnumerable<ShortLogViewModel>;

            if (logs == null)
            {
                logs = this.logService.GetAllSortedByDate()
                    .Select(l => this.factory.CreateShortLogViewModel(l));

                this.HttpContext.Cache[CachedLogsKey] = logs;
            }

            var model = logs
                .ToPagedList(page, count);

            return this.PartialView("_PagedLogListPartial", model);
        }

        public ActionResult List(int count = 10, int page = 1)
        {
            var logs = this.HttpContext.Cache[CachedLogsKey] as IEnumerable<ShortLogViewModel>;

            if (logs == null)
            {
                logs = this.logService.GetAllSortedByDate()
                    .Select(l => this.factory.CreateShortLogViewModel(l));

                this.HttpContext.Cache[CachedLogsKey] = logs;
            }

            var model = logs
                .ToPagedList(page, count);

            return this.View("List", model);
        }

        [OutputCache(Duration = 60 * 5)]
        public ActionResult TopLogs(int count = 3)
        {
            var logs = this.logService.GetTopLogs(count);
            var model = logs
                .Select(l => this.factory.CreateShortLogViewModel(l));

            return this.PartialView("_LogListPartial", model);
        }

        [OutputCache(Duration = 60 * 5)]
        public ActionResult Latest(int count = 3)
        {
            var logs = this.logService.GetLatestLogs(count);
            var model = logs
                .Select(l => this.factory.CreateShortLogViewModel(l));

            return this.PartialView("_LogListPartial", model);
        }

        [Authorize]
        [HttpPost]
        public PartialViewResult Edit(LogDetailsViewModel model)
        {
            this.logService.EditLogDescription(model.LogId, model.Description);

            return this.PartialView("_LogDescription", model.Description);
        }
    }
}