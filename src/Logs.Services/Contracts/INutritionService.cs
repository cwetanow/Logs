using System;
using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface INutritionService
    {
        NutritionEntry GetEntryByDate(string userId, DateTime date);

        Nutrition EditNutrition(int id, string userId, DateTime date, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar);
    }
}