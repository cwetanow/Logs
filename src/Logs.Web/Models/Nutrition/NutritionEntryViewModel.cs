using System;
using Logs.Models;

namespace Logs.Web.Models.Nutrition
{
    public class NutritionEntryViewModel
    {
        public NutritionEntryViewModel()
        {
            this.Nutrition = new NutritionViewModel();
            this.Measurements = new MeasurementViewModel();
        }

        public NutritionEntryViewModel(int id, DateTime date, NutritionViewModel nutrition, MeasurementViewModel measurement)
        {
            this.Id = id;
            this.Date = date;
            this.Nutrition = nutrition;
            this.Measurements = measurement;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public NutritionViewModel Nutrition { get; set; }

        public MeasurementViewModel Measurements { get; set; }
    }
}