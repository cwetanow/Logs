using System.Web.Mvc;
using Logs.Services.Contracts;
using Logs.Web.Models.Entries;
using Logs.Web.Models.Logs;
using PagedList;

namespace Logs.Web.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IEntryService entryService;

        public EntriesController(IEntryService entryService)
        {
            this.entryService = entryService;
        }

        public ActionResult List(int page, LogDetailsViewModel model, int count = 2)
        {
            model.Entries = model.Entries.ToPagedList(page, count);

            return this.PartialView("_LogEntriesPartial", model);
        }

        public ActionResult NewEntry(NewEntryViewModel model)
        {
            this.entryService.AddEntryToLog(model.Content, model.LogId);

            return null;
        }
    }
}