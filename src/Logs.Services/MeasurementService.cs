using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;
using System;

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
    }
}
