using System.Collections.Generic;
using System.Linq;

namespace Logs.Web.Models.Nutrition
{
    public class NutritionStatsViewModel
    {
        public NutritionStatsViewModel(IEnumerable<global::Logs.Models.Nutrition> nutritions)
        {
            this.Dates = nutritions.Select(m => m.Date.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture));
            this.Calories = nutritions.Select(m => m.Calories);
            this.Protein = nutritions.Select(m => m.Protein);
            this.Carbs = nutritions.Select(m => m.Carbs);
            this.Fats = nutritions.Select(m => m.Fats);
            this.Fiber = nutritions.Select(m => m.Fiber);
            this.WaterInLitres = nutritions.Select(m => m.WaterInLitres);
            this.Sugar = nutritions.Select(m => m.Sugar);

            this.ListModel = nutritions.Select(m => new DateIdViewModel(m.NutritionId,
                m.Date.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)))
                .Reverse();
        }

        public NutritionStatsViewModel()
        {

        }

        public IEnumerable<int> Calories { get; private set; }

        public IEnumerable<int> Carbs { get; private set; }

        public IEnumerable<string> Dates { get; set; }

        public IEnumerable<int> Fats { get; private set; }

        public IEnumerable<int> Fiber { get; private set; }

        public IEnumerable<DateIdViewModel> ListModel { get; set; }

        public IEnumerable<int> Protein { get; private set; }

        public IEnumerable<int> Sugar { get; private set; }

        public IEnumerable<double> WaterInLitres { get; private set; }
    }
}