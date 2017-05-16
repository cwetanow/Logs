﻿using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;
using Logs.Models;
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
        [ValidateAntiForgeryToken]
        public ActionResult Save(NutritionViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.authenticationProvider.CurrentUserId;

                var nutrition = (Nutrition)null;

                if (model.Id.HasValue)
                {
                    nutrition = this.nutritionService.EditNutrition(userId, model.Date, model.Id.Value, model.Calories, model.Protein, model.Carbs,
                        model.Fats, model.WaterInLitres, model.Fiber, model.Sugar, model.Notes);
                }
                else
                {
                    nutrition = this.nutritionService.CreateNutrition(model.Calories, model.Protein, model.Carbs,
                        model.Fats, model.WaterInLitres, model.Fiber, model.Sugar, model.Notes, userId, model.Date);
                }

                model = this.viewModelFactory.CreateNutritionViewModel(nutrition, model.Date);

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

                var nutrition = this.nutritionService.GetByDate(userId, date);

                var viewModel = this.viewModelFactory.CreateNutritionViewModel(nutrition, date);

                return this.PartialView(viewModel);
            }

            return null;
        }
    }
}