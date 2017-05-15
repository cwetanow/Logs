using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;
using System;
using System.Linq;

namespace Logs.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IRepository<Measurement> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly INutritionService nutritionService;
        private readonly IMeasurementFactory factory;

        public MeasurementService(IRepository<Measurement> repository,
            IUnitOfWork unitOfWork,
            INutritionService nutritionService,
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

            if (nutritionService == null)
            {
                throw new ArgumentNullException(nameof(nutritionService));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.nutritionService = nutritionService;
            this.factory = factory;
        }

        public Measurement UpdateMeasurement(int id, string userId, DateTime date, int height, double weightKg,
            double bodyFatPercent, int chest, int shoulders, int forearm, int arm, int waist,
            int hips, int thighs, int calves, int neck, int wrist, int ankle)
        {
            var measurement = this.EditMeasurement(id, height, weightKg,
                bodyFatPercent, chest, shoulders, forearm, arm, waist,
                hips, thighs, calves, neck, wrist, ankle);

            if (measurement == null)
            {
                var entry = this.nutritionService.GetEntryByDate(userId, date);

                if (entry == null)
                {
                    entry = this.nutritionService.CreateNutritionEntry(userId, date);
                }

                measurement = this.CreateMeasurement(height, weightKg,
                    bodyFatPercent, chest, shoulders, forearm, arm, waist,
                    hips, thighs, calves, neck, wrist, ankle, entry.NutritionEntryId);
            }

            return measurement;
        }

        public Measurement EditMeasurement(int id, int height, double weightKg, double bodyFatPercent, int chest, int shoulders, int forearm, int arm, int waist, int hips, int thighs, int calves, int neck, int wrist, int ankle)
        {
            var measurement = this.repository.GetById(id);

            if (measurement != null)
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

                this.unitOfWork.Commit();
            }

            return measurement;
        }

        public Measurement CreateMeasurement(int height, double weightKg, double bodyFatPercent, int chest, int shoulders, int forearm, int arm, int waist, int hips, int thighs, int calves, int neck, int wrist, int ankle, int entryId)
        {
            var measurement = this.factory.CreateMeasurement(height, weightKg,
              bodyFatPercent, chest, shoulders, forearm, arm, waist,
              hips, thighs, calves, neck, wrist, ankle, entryId);

            this.repository.Add(measurement);
            this.unitOfWork.Commit();

            return measurement;
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

                this.unitOfWork.Commit();
            }

            return measurement;
        }

        public Measurement CreateMeasurement(string userId, DateTime date, int height, double weightKg, double bodyFatPercent,
            int chest, int shoulders, int forearm, int arm,
            int waist, int hips, int thighs, int calves, int neck, int wrist, int ankle)
        {
            var measurement = this.factory.CreateMeasurement(userId, date, height, weightKg,
               bodyFatPercent, chest, shoulders, forearm, arm, waist,
               hips, thighs, calves, neck, wrist, ankle);

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
    }
}
