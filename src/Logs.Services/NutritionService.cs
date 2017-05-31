using System;
using System.Collections.Generic;
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

        public Nutrition EditNutrition(string userId, DateTime date, int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            var nutrition = this.nutritionRepository.GetById(id);

            if (nutrition != null && nutrition.UserId == userId && nutrition.Date == date)
            {
                nutrition.Calories = calories;
                nutrition.Protein = protein;
                nutrition.Carbs = carbs;
                nutrition.Fats = fats;
                nutrition.WaterInLitres = water;
                nutrition.Fiber = fiber;
                nutrition.Sugar = sugar;
                nutrition.Notes = notes;

                this.nutritionRepository.Update(nutrition);
                this.unitOfWork.Commit();
            }

            return nutrition;
        }

        public Nutrition CreateNutrition(int calories, int protein, int carbs, int fats, double water, int fiber, int sugar,
            string notes, string userId, DateTime date)
        {
            var nutrition = this.GetByDate(userId, date);

            if (nutrition != null)
            {
                return nutrition;
            }

            nutrition = this.nutritionFactory.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            this.nutritionRepository.Add(nutrition);
            this.unitOfWork.Commit();

            return nutrition;
        }

        public Nutrition GetByDate(string userId, DateTime date)
        {
            var result = this.nutritionRepository.All
                 .FirstOrDefault(n => n.UserId == userId && n.Date == date);

            return result;
        }

        public Nutrition GetById(int id)
        {
            return this.nutritionRepository.GetById(id);
        }

        public IEnumerable<Nutrition> GetUserNutritionsSortedByDate(string userId)
        {
            return this.nutritionRepository.All
                .Where(n => n.UserId == userId)
                .OrderBy(n => n.Date)
                .ToList();
        }

        public bool DeleteNutrition(int id, string userId)
        {
            var nutrition = this.nutritionRepository.GetById(id);

            if (nutrition != null && nutrition.UserId == userId)
            {
                this.nutritionRepository.Delete(nutrition);
                this.unitOfWork.Commit();

                return true;
            }

            return false;
        }
    }
}
