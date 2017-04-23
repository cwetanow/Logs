using System;
using System.Linq;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Common;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using PagedList;

namespace Logs.Web.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogService logService;
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IViewModelFactory factory;

        public LogsController(ILogService logService,
            IAuthenticationProvider authenticationProvider,
            IViewModelFactory factory)
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

        public ActionResult Details(int id, int page = 1, int count = Constants.LogEntriesPerPage)
        {
            var log = this.logService.GetTrainingLogById(id);

            if (log == null)
            {
                return HttpNotFound();
            }

            var isAuthenticated = this.authenticationProvider.IsAuthenticated;
            var currentUserId = this.authenticationProvider.CurrentUserId;

            var isAdmin = this.authenticationProvider.IsInRole(currentUserId, Constants.AdministratorRoleName);

            var canEdit = (log.User?.Id.Equals(currentUserId) ?? false) || isAdmin;
            var canVote = (log.Votes
                .FirstOrDefault(v => v.UserId.Equals(currentUserId))) == null && !canEdit && isAuthenticated;

            if (page < 0)
            {
                page = (log.Entries.Count - 1) / count + 1;
            }

            var entries = log.Entries
                .Select(e => LogEntryViewModel.FromEntry(e, currentUserId, isAdmin))
                .ToPagedList(page, count);

            var model = this.factory.CreateLogDetailsViewModel(log, isAuthenticated, canEdit, canVote, entries);

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
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLogViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.authenticationProvider.CurrentUserId;

            var log = this.logService.CreateTrainingLog(model.Name, model.Description, userId);

            return this.RedirectToAction("Details", new { id = log.LogId });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Edit(LogDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.logService.EditLog(model.LogId, model.Description, model.Name);
            }

            return this.PartialView("_LogDescription", model);
        }
    }
}