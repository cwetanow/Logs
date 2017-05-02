using System;
using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface INutritionService
    {
        NutritionEntry GetEntryByDate(string userId, DateTime date);
    }
}
