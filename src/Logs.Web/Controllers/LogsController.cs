using System;
using System.Web.Mvc;
using Logs.Services.Contracts;

namespace Logs.Web.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogService logService;

        public LogsController(ILogService logService)
        {
            if (logService == null)
            {
                throw new ArgumentNullException("logService");
            }

            this.logService = logService;
        }

        public ActionResult Details(int id)
        {
            var log = this.logService.GeTrainingLogById(id);

            return this.View();
        }
    }
}