namespace Logs.Models
{
    public class DailyNutritionGoals
    {
        public int DailyNutritionGoalsId { get; set; }

        public int Calories { get; set; }

        public int Protein { get; set; }

        public int Carbs { get; set; }

        public int Fats { get; set; }

        public double WaterInLitres { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
