﻿using System;

namespace Logs.Web.Models.Nutrition
{
    public class NutritionViewModel
    {
        public NutritionViewModel()
        {

        }

        public NutritionViewModel(global::Logs.Models.Nutrition nutrition, string notes = null)
        {
            if (nutrition != null)
            {
                this.Id = nutrition.NutritionId;
                this.Sugar = nutrition.Sugar;
                this.Fiber = nutrition.Fiber;
                this.WaterInLitres = nutrition.WaterInLitres;
                this.Fats = nutrition.Fats;
                this.Carbs = nutrition.Carbs;
                this.Protein = nutrition.Protein;
                this.Calories = nutrition.Calories;
            }

            this.Notes = notes;
        }

        public int Id { get; set; }

        public int Calories { get; set; }

        public int Protein { get; set; }

        public int Carbs { get; set; }

        public int Fats { get; set; }

        public double WaterInLitres { get; set; }

        public int Fiber { get; set; }

        public int Sugar { get; set; }

        public string Notes { get; set; }
    }
}