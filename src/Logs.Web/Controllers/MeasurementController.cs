using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using System.Web.Mvc;
using Logs.Web.Models.Nutrition;
using Logs.Web.Infrastructure.Factories;
using Logs.Models;
using Logs.Common;
using System;
using System.Linq;

namespace Logs.Web.Controllers
{
    public class MeasurementController : Controller
    {
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IMeasurementService measurementService;
        private readonly IViewModelFactory factory;

        public MeasurementController(IAuthenticationProvider authenticationProvider, IMeasurementService measurementService, IViewModelFactory factory)
        {
            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            if (measurementService == null)
            {
                throw new ArgumentNullException(nameof(measurementService));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.authenticationProvider = authenticationProvider;
            this.measurementService = measurementService;
            this.factory = factory;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MeasurementViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.authenticationProvider.CurrentUserId;

                var measurement = (Measurement)null;

                if (model.Id.HasValue)
                {
                    measurement = this.measurementService.EditMeasurement(userId, model.Date, model.Id.Value, model.Height, model.WeightKg,
                        model.BodyFatPercent, model.Chest, model.Shoulders, model.Forearm, model.Arm, model.Waist, model.Hips, model.Thighs,
                        model.Calves, model.Neck, model.Wrist, model.Ankle);
                }
                else
                {
                    measurement = this.measurementService.CreateMeasurement(model.Height, model.WeightKg,
                        model.BodyFatPercent, model.Chest, model.Shoulders, model.Forearm, model.Arm, model.Waist, model.Hips, model.Thighs,
                        model.Calves, model.Neck, model.Wrist, model.Ankle, userId, model.Date);
                }

                model = this.factory.CreateMeasurementViewModel(measurement, model.Date);

                model.SaveResult = Constants.SavedSuccessfully;
            }

            return this.PartialView("Load", model);
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

        public ActionResult Stats()
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var measurements = this.measurementService.GetUserMeasurementsSortedByDate(userId);

            var model = MeasurementStatsViewModel.FromMeasurement(measurements);

            return this.View(model);
        }
    }
}