using System;
using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface INutritionService
    {
        NutritionEntry GetEntryByDate(string userId, DateTime date);

        Nutrition UpdateNutrition(int id, string userId, DateTime date, int calories, int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes);

        Nutrition EditNutrition(int id, int calories, int protein, int carbs, int fats, double water, int fiber,
            int sugar, string notes);

        NutritionEntry CreateNutritionEntry(string userId, DateTime date);

        Nutrition CreateNutrition(int calories, int protein, int carbs, int fats, double water, int fiber, int sugar,
            string notes, NutritionEntry entry);
    }
}