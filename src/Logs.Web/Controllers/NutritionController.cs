using System;
using System.Web.Mvc;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;

namespace Logs.Web.Controllers
{
    public class NutritionController : Controller
    {
        private readonly IViewModelFactory viewModelFactory;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly INutritionService nutritionService;

        public NutritionController(IViewModelFactory viewModelFactory,
            IDateTimeProvider dateTimeProvider,
            INutritionService nutritionService)
        {
            this.viewModelFactory = viewModelFactory;
            this.dateTimeProvider = dateTimeProvider;
            this.nutritionService = nutritionService;
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
            return null;
        }
    }
}