using Logs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logs.Web.Models.Nutrition
{
    public class MeasurementStatsViewModel
    {
        public MeasurementStatsViewModel(IEnumerable<Measurement> measurements)
        {
            this.Dates = measurements.Select(m => m.Date.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture));
            this.Height = measurements.Select(m => m.Height);
            this.Ankle = measurements.Select(m => m.Ankle);
            this.WeightKg = measurements.Select(m => m.WeightKg);
            this.Wrist = measurements.Select(m => m.Wrist);
            this.Neck = measurements.Select(m => m.Neck);
            this.Calves = measurements.Select(m => m.Calves);
            this.Thighs = measurements.Select(m => m.Thighs);
            this.Hips = measurements.Select(m => m.Hips);
            this.Waist = measurements.Select(m => m.Waist);
            this.Arm = measurements.Select(m => m.Arm);
            this.Forearm = measurements.Select(m => m.Forearm);
            this.Shoulders = measurements.Select(m => m.Shoulders);
            this.Chest = measurements.Select(m => m.Chest);
            this.BodyFatPercent = measurements.Select(m => m.BodyFatPercent);

            this.ListModel = measurements.Select(m => new DateIdViewModel(m.MeasurementsId,
                m.Date.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)));
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

        public IEnumerable<DateIdViewModel> ListModel { get; set; }
    }
}