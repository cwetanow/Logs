using System;
using System.Collections.Generic;

namespace Logs.Models
{
    public class NutritionEntry
    {
        public NutritionEntry()
        {
            this.Meals = new HashSet<Meal>();
            this.Nutritions = new HashSet<Nutrition>();
        }

        public int NutritionEntryId { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public string Notes { get; set; }

        public int? MeasurementsId { get; set; }

        public int? NutritionId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }

        public virtual Measurement Measurement { get; set; }

        public virtual Nutrition Nutrition { get; set; }

        public virtual ICollection<Nutrition> Nutritions { get; set; }
    }
}
