using System;
using System.Linq;
using System.Web.Mvc;
using Logs.Common;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using PagedList;

namespace Logs.Web.Controllers
{
    public class ListController : Controller
    {
        private readonly ILogService logService;
        private readonly IViewModelFactory factory;

        public ListController(ILogService logService,
            IViewModelFactory factory)
        {
            if (logService == null)
            {
                throw new ArgumentNullException(nameof(logService));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.logService = logService;
            this.factory = factory;
        }

        [HttpGet]
        [OutputCache(Duration = 60 * 5, VaryByParam = "page")]
        public ActionResult PartialList(int count = Constants.LogsPerPage, int page = 1)
        {
            var logs = this.logService.GetAllSortedByDate()
                    .Select(l => this.factory.CreateShortLogViewModel(l));

            var model = logs
                .ToPagedList(page, count);

            return this.PartialView("_PagedLogListPartial", model);
        }

        [HttpGet]
        public ActionResult List()
        {
            return this.View();
        }

        [HttpGet]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult TopLogs(int count = Constants.TopLogsCount)
        {
            var logs = this.logService.GetTopLogs(count);
            var model = logs
                .Select(l => this.factory.CreateShortLogViewModel(l));

            return this.PartialView("_LogListPartial", model);
        }

        [HttpGet]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult Latest(int count = Constants.TopLogsCount)
        {
            var logs = this.logService.GetLatestLogs(count);
            var model = logs
                .Select(l => this.factory.CreateShortLogViewModel(l));

            return this.PartialView("_LogListPartial", model);
        }
    }
}