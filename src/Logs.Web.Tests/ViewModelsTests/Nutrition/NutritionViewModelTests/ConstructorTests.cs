using Logs.Web.Models.Nutrition;
using NUnit.Framework;
using System;

namespace Logs.Web.Tests.ViewModelsTests.Nutrition.NutritionViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassNutritionNull_ShouldSetDateCorrectly()
        {
            // Arrange
            var date = new DateTime(1, 2, 3);

            // Act
            var model = new NutritionViewModel(null, date);

            // Assert
            Assert.AreEqual(date, model.Date);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_PassNutrition_ShouldSetIdCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null, date);
            nutrition.NutritionId = id;

            // Act
            var model = new NutritionViewModel(nutrition, date);

            // Assert
            Assert.AreEqual(id, model.Id);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_PassNutrition_ShouldSetSugarCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null, date);
            nutrition.NutritionId = id;

            // Act
            var model = new NutritionViewModel(nutrition, date);

            // Assert
            Assert.AreEqual(sugar, model.Sugar);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_PassNutrition_ShouldSetFiberCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null, date);
            nutrition.NutritionId = id;

            // Act
            var model = new NutritionViewModel(nutrition, date);

            // Assert
            Assert.AreEqual(fiber, model.Fiber);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_PassNutrition_ShouldSetWaterInLitresCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null, date);
            nutrition.NutritionId = id;

            // Act
            var model = new NutritionViewModel(nutrition, date);

            // Assert
            Assert.AreEqual(water, model.WaterInLitres);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_PassNutrition_ShouldSetFatsCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null, date);
            nutrition.NutritionId = id;

            // Act
            var model = new NutritionViewModel(nutrition, date);

            // Assert
            Assert.AreEqual(fats, model.Fats);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_PassNutrition_ShouldSetCarbsCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null, date);
            nutrition.NutritionId = id;

            // Act
            var model = new NutritionViewModel(nutrition, date);

            // Assert
            Assert.AreEqual(carbs, model.Carbs);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_PassNutrition_ShouldSetProteinCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null, date);
            nutrition.NutritionId = id;

            // Act
            var model = new NutritionViewModel(nutrition, date);

            // Assert
            Assert.AreEqual(protein, model.Protein);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_PassNutrition_ShouldSetCaloriesCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null, date);
            nutrition.NutritionId = id;

            // Act
            var model = new NutritionViewModel(nutrition, date);

            // Assert
            Assert.AreEqual(calories, model.Calories);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_PassNutrition_ShouldSetNotesCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null, date);
            nutrition.NutritionId = id;

            // Act
            var model = new NutritionViewModel(nutrition, date);

            // Assert
            Assert.AreEqual(notes, model.Notes);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_PassNutrition_ShouldSetDateCorrectly(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null, date);
            nutrition.NutritionId = id;

            // Act
            var model = new NutritionViewModel(nutrition, new DateTime());

            // Assert
            Assert.AreEqual(date, model.Date);
        }
    }
}
