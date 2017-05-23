using Logs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logs.Web.Models.Nutrition
{
    public class MeasurementStatsViewModel
    {
        public static Func<IEnumerable<Measurement>, MeasurementStatsViewModel> FromMeasurement
        {
            get
            {
                return (measurements) => new MeasurementStatsViewModel
                {
                    Dates = measurements.Select(m => m.Date.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                    Height = measurements.Select(m => m.Height),
                    Ankle = measurements.Select(m => m.Ankle),
                    WeightKg = measurements.Select(m => m.WeightKg),
                    Wrist = measurements.Select(m => m.Wrist),
                    Neck = measurements.Select(m => m.Neck),
                    Calves = measurements.Select(m => m.Calves),
                    Thighs = measurements.Select(m => m.Thighs),
                    Hips = measurements.Select(m => m.Hips),
                    Waist = measurements.Select(m => m.Waist),
                    Arm = measurements.Select(m => m.Arm),
                    Forearm = measurements.Select(m => m.Forearm),
                    Shoulders = measurements.Select(m => m.Shoulders),
                    Chest = measurements.Select(m => m.Chest),
                    BodyFatPercent = measurements.Select(m => m.BodyFatPercent)
                };
            }
        }

        public IEnumerable<int> Height { get; set; }

        public IEnumerable<double> WeightKg { get; set; }

        public IEnumerable<double> BodyFatPercent { get; set; }

        public IEnumerable<int> Chest { get; set; }

        public IEnumerable<int> Shoulders { get; set; }

        public IEnumerable<int> Forearm { get; set; }

        public IEnumerable<int> Arm { get; set; }

        public IEnumerable<int> Waist { get; set; }

        public IEnumerable<int> Hips { get; set; }

        public IEnumerable<int> Thighs { get; set; }

        public IEnumerable<int> Calves { get; set; }

        public IEnumerable<int> Neck { get; set; }

        public IEnumerable<int> Wrist { get; set; }

        public IEnumerable<int> Ankle { get; set; }

        public IEnumerable<string> Dates { get; set; }
    }
}