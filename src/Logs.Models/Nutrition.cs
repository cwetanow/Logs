using System;

namespace Logs.Models
{
    public class Nutrition
    {
        public int NutritionId { get; set; }

        public string Notes { get; set; }

        public DateTime Date { get; set; }

        public int Calories { get; set; }

        public int GoalCalories { get; set; }

        public int Protein { get; set; }

        public int GoalProtein { get; set; }

        public int Carbs { get; set; }

        public int GoalCarbs { get; set; }

        public int Fats { get; set; }

        public int GoalFats { get; set; }

        public double WaterInLitres { get; set; }

        public double GoalWaterInLitres { get; set; }
        
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
