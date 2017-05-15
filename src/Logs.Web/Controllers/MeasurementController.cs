using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using System.Web.Mvc;
using Logs.Web.Models.Nutrition;

namespace Logs.Web.Controllers
{
    public class MeasurementController : Controller
    {
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IMeasurementService measurementService;

        public MeasurementController(IAuthenticationProvider authenticationProvider, IMeasurementService measurementService)
        {
            this.authenticationProvider = authenticationProvider;
            this.measurementService = measurementService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MeasurementViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}