using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Models.Entries;
using Logs.Web.Models.Logs;

namespace Logs.Web.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IEntryService entryService;
        private readonly IAuthenticationProvider authenticationProvider;

        public EntriesController(IEntryService entryService, IAuthenticationProvider authenticationProvider)
        {
            if (entryService == null)
            {
                throw new ArgumentNullException(nameof(entryService));
            }

            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            this.entryService = entryService;
            this.authenticationProvider = authenticationProvider;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewEntry(NewEntryViewModel model)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            this.entryService.AddEntryToLog(model.Content, model.LogId, userId);

            return this.RedirectToAction("Details", "Logs", new { id = model.LogId, page = -1 });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult EditEntry(LogEntryViewModel model)
        {
            var result = this.entryService.EditEntry(model.EntryId, model.Content);
            model.Content = result.Content;

            return this.PartialView("_EntryContentPartial", model);
        }
    }
}