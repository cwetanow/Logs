using System.Linq;
using System.Web.Mvc;
using Logs.Services.Contracts;
using Logs.Web.Models.Logs;
using PagedList;

namespace Logs.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = AdministratorRoleName)]
    public class LogsAdministrationController : Controller
    {
        private const string AdministratorRoleName = "administrator";

        private readonly ILogService logService;

        public LogsAdministrationController(ILogService logService)
        {
            this.logService = logService;
        }

        public ActionResult Index(int page = 1, int count = 10)
        {
            var logs = this.logService.GetAll()
                .Select(l => new ShortLogViewModel(l))
                .ToPagedList(page, count);

            return this.View(logs);
        }

        public ActionResult Delete(int id)
        {
            this.logService.DeleteLog(id);

            return this.RedirectToAction("Index");
        }
    }
}