using System;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using System.Web.Mvc;
using Logs.Web.Models.Nutrition;
using Logs.Web.Infrastructure.Factories;

namespace Logs.Web.Controllers
{
    public class MeasurementController : Controller
    {
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IMeasurementService measurementService;
        private readonly IViewModelFactory factory;

        public MeasurementController(IAuthenticationProvider authenticationProvider, IMeasurementService measurementService, IViewModelFactory factory)
        {
            this.authenticationProvider = authenticationProvider;
            this.measurementService = measurementService;
            this.factory = factory;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MeasurementViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Load(InputViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var date = model.Date;
                var userId = this.authenticationProvider.CurrentUserId;

                var measurement = this.measurementService.GetByDate(userId, date);

                var viewModel = this.factory.CreateMeasurementViewModel(measurement, date);

                return this.PartialView(viewModel);
            }

            return null;
        }
    }
}