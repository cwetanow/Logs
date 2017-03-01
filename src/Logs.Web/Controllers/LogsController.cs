using System;
using System.Web.Mvc;
using Logs.Services.Contracts;
using Logs.Web.Models;
using Microsoft.AspNet.Identity;

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
            var log = this.logService.GetTrainingLogById(id);

            return this.View();
        }

        [Authorize]
        public ActionResult CreateLog()
        {
            return this.View(new CreateLogViewModel());
        }

        [Authorize]
        [HttpPost]
        public RedirectToRouteResult CreateLog(CreateLogViewModel model)
        {
            var log = this.logService.CreateTrainingLog(model.Name, model.Description, this.HttpContext.User.Identity.GetUserId());

            return this.RedirectToAction("Details", new { id = log.LogId });
        }

        public ActionResult List()
        {
            var model = this.logService.GetLogs();
            return this.View(model);
        }
    }
}