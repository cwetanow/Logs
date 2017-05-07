using System;
using Logs.Models;

namespace Logs.Web.Models.Nutrition
{
    public class MeasurementViewModel
    {
        public MeasurementViewModel()
        {

        }

        public MeasurementViewModel(Measurement measurement, DateTime date)
        {
            if (measurement != null)
            {
                this.Id = measurement.MeasurementsId;
                this.NutritionEntryId = measurement.NutritionEntryId;
                this.Heigh = measurement.Heigh;
                this.WeightKg = measurement.WeightKg;
                this.BodyFatPercent = measurement.BodyFatPercent;
                this.Chest = measurement.Chest;
                this.Shoulders = measurement.Shoulders;
                this.Forearm = measurement.Forearm;
                this.Arm = measurement.Arm;
                this.Waist = measurement.Waist;
                this.Hips = measurement.Hips;
                this.Thighs = measurement.Thighs;
                this.Calves = measurement.Calves;
                this.Neck = measurement.Neck;
                this.Wrist = measurement.Wrist;
                this.Ankle = measurement.Ankle;
            }

            this.Date = date;
        }
        
        public string SaveResult { get; set; }

        public DateTime Date { get; set; }

        public int Id { get; set; }

        public int NutritionEntryId { get; set; }

        public int Heigh { get; set; }

        public double WeightKg { get; set; }

        public double BodyFatPercent { get; set; }

        public int Chest { get; set; }

        public int Shoulders { get; set; }

        public int Forearm { get; set; }

        public int Arm { get; set; }

        public int Waist { get; set; }

        public int Hips { get; set; }

        public int Thighs { get; set; }

        public int Calves { get; set; }

        public int Neck { get; set; }

        public int Wrist { get; set; }

        public int Ankle { get; set; }
    }
}