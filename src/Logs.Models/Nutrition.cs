using System;
using System.Collections.Generic;

namespace Logs.Models
{
    public class Nutrition
    {
        public Nutrition()
        {
        }

        public Nutrition(int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes, object entry)
            : this()
        {
            this.Calories = calories;
            this.Protein = protein;
            this.Carbs = carbs;
            this.Fats = fats;
            this.WaterInLitres = water;
            this.Fiber = fiber;
            this.Sugar = sugar;
            this.Notes = notes;
        }

        public int NutritionId { get; set; }

        public string Notes { get; set; }

        public int Calories { get; set; }

        public int Protein { get; set; }

        public int Carbs { get; set; }

        public int Fats { get; set; }

        public double WaterInLitres { get; set; }

        public int Fiber { get; set; }

        public int Sugar { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
