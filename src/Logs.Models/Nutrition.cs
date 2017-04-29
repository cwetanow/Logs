using System.Collections.Generic;

namespace Logs.Models
{
    public class Nutrition
    {
        public Nutrition()
        {
            this.NutritionEntries = new HashSet<NutritionEntry>();
        }

        public int NutritionId { get; set; }

        public int Calories { get; set; }

        public int Protein { get; set; }

        public int Carbs { get; set; }

        public int Fats { get; set; }

        public double WaterInLitres { get; set; }

        public int Fiber { get; set; }

        public int Sugar { get; set; }

        public int EntryId { get; set; }

        public virtual ICollection<NutritionEntry> NutritionEntries { get; set; }

        public virtual NutritionEntry NutritionEntry { get; set; }
    }
}
