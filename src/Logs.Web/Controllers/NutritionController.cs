using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;
using Logs.Common;

namespace Logs.Web.Controllers
{
    [Authorize]
    public class NutritionController : Controller
    {
        private readonly IViewModelFactory viewModelFactory;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly INutritionService nutritionService;
        private readonly IAuthenticationProvider authenticationProvider;

        public NutritionController(IViewModelFactory viewModelFactory,
            IDateTimeProvider dateTimeProvider,
            INutritionService nutritionService,
            IAuthenticationProvider authenticationProvider)
        {
            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            if (dateTimeProvider == null)
            {
                throw new ArgumentNullException(nameof(dateTimeProvider));
            }

            if (nutritionService == null)
            {
                throw new ArgumentNullException(nameof(nutritionService));
            }

            this.viewModelFactory = viewModelFactory;
            this.dateTimeProvider = dateTimeProvider;
            this.nutritionService = nutritionService;
            this.authenticationProvider = authenticationProvider;
        }

        public ActionResult Input()
        {
            var date = this.dateTimeProvider.GetCurrentTime();

            var model = this.viewModelFactory.CreateInputViewModel(date);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult LoadEntry(InputViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.authenticationProvider.CurrentUserId;
                var entry = this.nutritionService.GetEntryByDate(userId, model.Date);

                var measurement = entry?.Measurement;
                var measurementModel = this.viewModelFactory.CreateMeasurementViewModel(measurement, model.Date);

                var nutrition = entry?.Nutrition;
                var nutritionModel = this.viewModelFactory.CreateNutritionViewModel(nutrition, model.Date);

                var entryId = entry?.NutritionEntryId ?? 0;

                var viewModel = this.viewModelFactory.CreateNutritionEntryViewModel(entryId,
                      model.Date,
                      nutritionModel,
                      measurementModel);

                return this.PartialView("NutritionEntryPartial", viewModel);
            }

            return null;
        }

        [HttpPost]
        public ActionResult SaveEntry(NutritionViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.authenticationProvider.CurrentUserId;

                var result = this.nutritionService.UpdateNutrition(model.Id, userId, model.Date,
                       model.Calories,
                       model.Protein,
                       model.Carbs,
                       model.Fats,
                       model.WaterInLitres,
                       model.Fiber,
                       model.Sugar,
                       model.Notes);

                if (result != null)
                {
                    model.Calories = result.Calories;
                    model.Carbs = result.Carbs;
                    model.Fats = result.Fats;
                    model.Fiber = result.Fiber;
                    model.Notes = result.Notes;
                    model.Protein = result.Protein;
                    model.Sugar = result.Sugar;
                    model.WaterInLitres = result.WaterInLitres;

                    model.SaveResult = Constants.SavedSuccessfully;
                }
            }

            return this.PartialView("NutritionEditPartial", model);
        }
    }
}