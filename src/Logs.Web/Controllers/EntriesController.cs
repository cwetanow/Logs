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
            this.entryService = entryService;
            this.authenticationProvider = authenticationProvider;
        }

        public ActionResult NewEntry(NewEntryViewModel model)
        {
            this.entryService.AddEntryToLog(model.Content, model.LogId);

            return this.RedirectToAction("Details", "Logs", new { id = model.LogId });
        }

        public ActionResult Comment(NewCommentViewModel model)
        {
            model.UserId = authenticationProvider.CurrentUserId;

            this.entryService.AddCommentToLog(model.Content, model.LogId, model.UserId);

            return this.RedirectToAction("Details", "Logs", new { id = model.LogId });
        }
    }
}