using System;

namespace Logs.Models
{
    public class Measurement
    {
        public Measurement()
        {
        }

        public Measurement(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId,
                  DateTime date)
        {
            this.Height = height;
            this.WeightKg = weightKg;
            this.BodyFatPercent = bodyFatPercent;
            this.Chest = chest;
            this.Shoulders = shoulders;
            this.Forearm = forearm;
            this.Arm = arm;
            this.Waist = waist;
            this.Hips = hips;
            this.Thighs = thighs;
            this.Calves = calves;
            this.Neck = neck;
            this.Wrist = wrist;
            this.Ankle = ankle;
            this.UserId = userId;
            this.Date = date;
        }

        public int MeasurementsId { get; set; }

        public int Height { get; set; }

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

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
