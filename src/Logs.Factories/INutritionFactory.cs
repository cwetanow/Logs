using Logs.Models;

namespace Logs.Factories
{
    public interface INutritionFactory
    {
        NutritionEntry CreateNutritionEntry();

        Nutrition CreateNutrition();
    }
}
