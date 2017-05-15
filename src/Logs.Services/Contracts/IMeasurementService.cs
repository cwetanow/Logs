using Logs.Models;
using System;

namespace Logs.Services.Contracts
{
    public interface IMeasurementService
    {
        Measurement EditMeasurement(string userId, DateTime date, int id, int height,
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
                  int ankle);

        Measurement CreateMeasurement(string userId,
                    DateTime date,
                    int height,
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
                    int ankle);

        Measurement GetByDate(string userId, DateTime date);
    }
}
