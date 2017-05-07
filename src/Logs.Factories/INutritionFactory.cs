using System;
using Logs.Models;

namespace Logs.Factories
{
    public interface INutritionFactory
    {
        NutritionEntry CreateNutritionEntry(string userId, DateTime date);

        Nutrition CreateNutrition(int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes, NutritionEntry entry);
    }
}
