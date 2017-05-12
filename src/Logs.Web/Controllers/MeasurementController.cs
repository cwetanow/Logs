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

        [HttpPost]
        public ActionResult SaveMeasurement(MeasurementViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.authenticationProvider.CurrentUserId;

                var result = this.measurementService.UpdateMeasurement(model.Id, userId, model.Date,
                    model.Height,
                    model.WeightKg,
                    model.BodyFatPercent,
                    model.Chest,
                    model.Shoulders,
                    model.Forearm,
                    model.Arm,
                    model.Waist,
                    model.Hips,
                    model.Thighs,
                    model.Calves,
                    model.Neck,
                    model.Wrist,
                    model.Ankle);

                if (result != null)
                {
                    model.Height = result.Height;
                    model.WeightKg = result.WeightKg;
                    model.BodyFatPercent = result.BodyFatPercent;
                    model.Chest = result.Chest;
                    model.Shoulders = result.Shoulders;
                    model.Forearm = result.Forearm;
                    model.Arm = result.Arm;
                    model.Waist = result.Waist;
                    model.Hips = result.Hips;
                    model.Thighs = result.Thighs;
                    model.Calves = result.Calves;
                    model.Neck = result.Neck;
                    model.Wrist = result.Wrist;
                    model.Ankle = result.Ankle;

                    model.SaveResult = Constants.SavedSuccessfully;
                }
            }

            return this.PartialView("MeasurementEditPartial", model);
        }
    }
}