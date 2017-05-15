using System;
using System.Linq;
using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;

namespace Logs.Services
{
    public class NutritionService : INutritionService
    {
        private readonly IRepository<Nutrition> nutritionRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly INutritionFactory nutritionFactory;

        public NutritionService(IRepository<Nutrition> nutritionRepository,
            IUnitOfWork unitOfWork,
            INutritionFactory nutritionFactory)
        {
            if (nutritionRepository == null)
            {
                throw new ArgumentNullException(nameof(nutritionRepository));
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            if (nutritionFactory == null)
            {
                throw new ArgumentNullException(nameof(nutritionFactory));
            }

            this.nutritionRepository = nutritionRepository;
            this.unitOfWork = unitOfWork;
            this.nutritionFactory = nutritionFactory;
        }
    }
}
