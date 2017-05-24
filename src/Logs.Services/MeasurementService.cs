using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Logs.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IRepository<Measurement> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMeasurementFactory factory;

        public MeasurementService(IRepository<Measurement> repository,
            IUnitOfWork unitOfWork,
            IMeasurementFactory factory)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }

        public Measurement EditMeasurement(string userId, DateTime date, int id, int height, double weightKg, double bodyFatPercent, int chest, int shoulders, int forearm, int arm, int waist, int hips, int thighs, int calves, int neck, int wrist, int ankle)
        {
            var measurement = this.repository.GetById(id);

            if (measurement != null && measurement.UserId == userId && measurement.Date == date)
            {
                measurement.Height = height;
                measurement.WeightKg = weightKg;
                measurement.BodyFatPercent = bodyFatPercent;
                measurement.Chest = chest;
                measurement.Shoulders = shoulders;
                measurement.Forearm = forearm;
                measurement.Arm = arm;
                measurement.Waist = waist;
                measurement.Hips = hips;
                measurement.Thighs = thighs;
                measurement.Calves = calves;
                measurement.Neck = neck;
                measurement.Wrist = wrist;
                measurement.Ankle = ankle;

                this.repository.Update(measurement);
                this.unitOfWork.Commit();
            }

            return measurement;
        }

        public Measurement CreateMeasurement(int height, double weightKg, double bodyFatPercent,
            int chest, int shoulders, int forearm, int arm,
            int waist, int hips, int thighs, int calves, int neck, int wrist, int ankle, string userId, DateTime date)
        {
            var measurement = this.GetByDate(userId, date);

            if (measurement != null)
            {
                return measurement;
            }

            measurement = this.factory.CreateMeasurement(height, weightKg,
              bodyFatPercent, chest, shoulders, forearm, arm, waist,
              hips, thighs, calves, neck, wrist, ankle, userId, date);

            this.repository.Add(measurement);
            this.unitOfWork.Commit();

            return measurement;
        }

        public Measurement GetByDate(string userId, DateTime date)
        {
            var result = this.repository.All
                 .FirstOrDefault(m => m.UserId == userId && m.Date == date);

            return result;
        }

        public IEnumerable<Measurement> GetUserMeasurementsSortedByDate(string userId)
        {
            var result = this.repository.All
                .Where(m => m.UserId == userId)
                .OrderBy(m => m.Date)
                .ToList();

            return result;
        }

        public Measurement GetById(int id)
        {
            return this.repository.GetById(id);
        }
    }
}
