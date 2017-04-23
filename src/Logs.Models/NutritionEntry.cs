using System;
using System.Collections.Generic;

namespace Logs.Models
{
    public class NutritionEntry
    {
        public NutritionEntry()
        {
            this.Meals = new HashSet<Meal>();
        }

        public int NutritionEntryId { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }

        public virtual Measurements Measurements { get; set; }

        public virtual Nutrition Nutrition { get; set; }

        public string Notes { get; set; }
    }
}
