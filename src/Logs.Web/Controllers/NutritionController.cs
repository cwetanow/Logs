using System;
using System.Web.Mvc;
using Logs.Web.Models.Nutrition;

namespace Logs.Web.Controllers
{
    public class NutritionController : Controller
    {
        public ActionResult Input()
        {
            var model = new InputViewModel { Date = DateTime.Now };
            return this.View(model);
        }

        [HttpPost]
        public ActionResult Input(InputViewModel model)
        {
            return null;
        }
    }
}