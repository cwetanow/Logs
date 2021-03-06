﻿using Logs.Models;
using System;

namespace Logs.Factories
{
    public interface IMeasurementFactory
    {
        Measurement CreateMeasurement(int height,
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
                  DateTime date);
    }
}
