using System;
using System.Linq;
using System.Web.Mvc;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using PagedList;

namespace Logs.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = Common.Constants.AdministratorRoleName)]
    public class LogsAdministrationController : Controller
    {
        private readonly ILogService logService;
        private readonly IViewModelFactory viewModelFactory;

        public LogsAdministrationController(ILogService logService, IViewModelFactory viewModelFactory)
        {
            if (logService == null)
            {
                throw new ArgumentNullException(nameof(logService));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.logService = logService;
            this.viewModelFactory = viewModelFactory;
        }

        public ActionResult Index(int page = 1, int count = 10)
        {
            var logs = this.logService.GetAll()
                .Select(this.viewModelFactory.CreateShortLogViewModel)
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