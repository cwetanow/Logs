using System.Web.Mvc;
using Logs.Web.Models.Entries;
using Logs.Web.Models.Logs;
using PagedList;

namespace Logs.Web.Controllers
{
    public class EntriesController : Controller
    {
        public ActionResult List(int page, LogDetailsViewModel model, int count = 10)
        {
            model.Entries = model.Entries.ToPagedList(page, count);

            return this.PartialView("_LogEntriesPartial", model);
        }

        public ActionResult NewEntry(NewEntryViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}