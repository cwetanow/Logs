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

        Nutrition EditNutrition(string userId, DateTime date, int id, int calories, int protein, int carbs, int fats, double water, int fiber,
            int sugar, string notes);

        NutritionEntry CreateNutritionEntry(string userId, DateTime date);

        Nutrition CreateNutrition(int calories, int protein, int carbs, int fats, double water, int fiber, int sugar,
            string notes, NutritionEntry entry);

        Nutrition CreateNutrition(int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes,
            string userId, DateTime date);

        Nutrition GetByDate(string userId, DateTime date);
    }
}