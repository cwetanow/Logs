using System;

namespace Logs.Models
{
    public class Meal
    {
        public int MealId { get; set; }

        public DateTime Time { get; set; }

        public string Content { get; set; }

        public int EntryId { get; set; }

        public virtual NutritionEntry NutritionEntry { get; set; }
    }
}
