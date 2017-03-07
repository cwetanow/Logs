using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Models.Entries;

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
        public ActionResult NewEntry(NewEntryViewModel model)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            this.entryService.AddEntryToLog(model.Content, model.LogId, userId);

            return this.RedirectToAction("Details", "Logs", new { id = model.LogId });
        }

        [Authorize]
        public ActionResult Comment(NewCommentViewModel model)
        {
            model.UserId = this.authenticationProvider.CurrentUserId;

            this.entryService.AddCommentToLog(model.Content, model.LogId, model.UserId);

            return this.RedirectToAction("Details", "Logs", new { id = model.LogId });
        }
    }
}