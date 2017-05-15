﻿using System;
using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface INutritionService
    {
        Nutrition EditNutrition(string userId, DateTime date, int id, int calories, int protein, int carbs, int fats, double water, int fiber,
            int sugar, string notes);

        Nutrition CreateNutrition(int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes,
             string userId, DateTime date);

        Nutrition GetByDate(string userId, DateTime date);
    }
}