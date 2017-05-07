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
        private readonly IRepository<NutritionEntry> entryRepository;
        private readonly IRepository<Nutrition> nutritionRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly INutritionFactory nutritionFactory;

        public NutritionService(IRepository<NutritionEntry> entryRepository,
            IRepository<Nutrition> nutritionRepository,
            IUnitOfWork unitOfWork,
            INutritionFactory nutritionFactory)
        {
            this.entryRepository = entryRepository;
            this.nutritionRepository = nutritionRepository;
            this.unitOfWork = unitOfWork;
            this.nutritionFactory = nutritionFactory;
        }

        public NutritionEntry GetEntryByDate(string userId, DateTime date)
        {
            var entry = this.entryRepository.All
                .FirstOrDefault(e => e.UserId == userId && e.Date.Equals(date));

            return entry;
        }

        public Nutrition EditNutrition(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            var nutrition = this.nutritionRepository.GetById(id);

            if (nutrition != null)
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

        public NutritionEntry CreateNutritionEntry(string userId, DateTime date)
        {
            var entry = this.nutritionFactory.CreateNutritionEntry(userId, date);

            this.entryRepository.Add(entry);
            this.unitOfWork.Commit();

            return entry;
        }

        public Nutrition CreateNutrition(int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes,
            NutritionEntry entry)
        {
            var nutrition = this.nutritionFactory.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, entry);

            this.nutritionRepository.Add(nutrition);
            this.unitOfWork.Commit();

            return nutrition;
        }

        public Nutrition UpdateNutrition(int id, string userId, DateTime date, int calories, int protein, int carbs,
            int fats, double water, int fiber, int sugar, string notes)
        {
            var nutrition = this.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            if (nutrition == null)
            {
                var entry = this.GetEntryByDate(userId, date);

                if (entry == null)
                {
                    entry = this.CreateNutritionEntry(userId, date);
                }

                nutrition = this.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, entry);

                entry.NutritionId = nutrition.NutritionId;

                this.entryRepository.Update(entry);
                this.unitOfWork.Commit();
            }

            return nutrition;
        }
    }
}
