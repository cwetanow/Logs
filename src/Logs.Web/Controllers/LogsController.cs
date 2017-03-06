using System;
using System.Linq;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Models.Logs;
using Microsoft.AspNet.Identity;
using PagedList;

namespace Logs.Web.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogService logService;
        private readonly IAuthenticationProvider authenticationProvider;

        public LogsController(ILogService logService, IAuthenticationProvider authenticationProvider)
        {
            if (logService == null)
            {
                throw new ArgumentNullException("logService");
            }

            if (authenticationProvider == null)
            {
                throw new ArgumentNullException("authenticationProvider");
            }

            this.logService = logService;
            this.authenticationProvider = authenticationProvider;
        }

        public ActionResult Details(int id, int page = 1, int count = 3)
        {
            var log = this.logService.GetTrainingLogById(id);

            var isAuthenticated = this.authenticationProvider.IsAuthenticated;

            var isOwner = false;
            var canVote = false;

            var entries = log.Entries
                .Select(e => new LogEntryViewModel(e))
                .ToPagedList(page, count);

            if (isAuthenticated)
            {
                var currentUserId = this.authenticationProvider.CurrentUserId;

                isOwner = log.User.Id.Equals(currentUserId);
                canVote = (log.Votes
                    .FirstOrDefault(v => v.UserId.Equals(currentUserId))) == null && !isOwner;
            }

            var model = new LogDetailsViewModel(log, isAuthenticated, isOwner, canVote, entries);

            return this.View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.View(new CreateLogViewModel());
        }

        [Authorize]
        [HttpPost]
        public RedirectToRouteResult CreateLog(CreateLogViewModel model)
        {
            var log = this.logService.CreateTrainingLog(model.Name, model.Description, this.HttpContext.User.Identity.GetUserId());

            return this.RedirectToAction("Details", new { id = log.LogId });
        }

        public ActionResult PartialList(int count = 10, int page = 1)
        {
            var logs = this.logService.GetAllSortedByDate();
            var model = logs
                .Select(l => new ShortLogViewModel(l))
                .ToPagedList(page, count);

            return this.PartialView("_PagedLogListPartial", model);
        }

        public ActionResult List(int count = 10, int page = 1)
        {
            var logs = this.logService.GetAllSortedByDate();
            var model = logs
                .Select(l => new ShortLogViewModel(l))
                .ToPagedList(page, count);

            return this.View("List", model);
        }

        [OutputCache(Duration = 60 * 5)]
        public ActionResult TopLogs(int count = 3)
        {
            var logs = this.logService.GetTopLogs(count);
            var model = logs
                .Select(l => new ShortLogViewModel(l));

            return this.PartialView("_LogListPartial", model);
        }

        [OutputCache(Duration = 60 * 5)]
        public ActionResult Latest(int count = 3)
        {
            var logs = this.logService.GetLatestLogs(count);
            var model = logs
                .Select(l => new ShortLogViewModel(l));

            return this.PartialView("_LogListPartial", model);
        }
    }
}