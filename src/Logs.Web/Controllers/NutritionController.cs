using System;
using System.Web.Mvc;
using Logs.Providers.Contracts;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;

namespace Logs.Web.Controllers
{
    public class NutritionController : Controller
    {
        private readonly IViewModelFactory viewModelFactory;
        private readonly IDateTimeProvider dateTimeProvider;

        public NutritionController(IViewModelFactory viewModelFactory, IDateTimeProvider dateTimeProvider)
        {
            this.viewModelFactory = viewModelFactory;
            this.dateTimeProvider = dateTimeProvider;
        }

        public ActionResult Input()
        {
            var date = this.dateTimeProvider.GetCurrentTime();

            var model = this.viewModelFactory.CreateInputViewModel(date);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Input(InputViewModel model)
        {
            return null;
        }
    }
}