using System.Web.Mvc;
using Logs.Services.Contracts;

namespace Logs.Web.Controllers
{
    public class NutritionController : Controller
    {
        private readonly INutritionService nutritionService;

        public NutritionController(INutritionService nutritionService)
        {
            this.nutritionService = nutritionService;
        }
    }
}