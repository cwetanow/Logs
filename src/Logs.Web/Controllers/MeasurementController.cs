using Logs.Authentication.Contracts;
using Logs.Common;
using Logs.Services.Contracts;
using Logs.Web.Models.Nutrition;
using System.Web.Mvc;

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
    }
}