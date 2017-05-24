using Logs.Web.Models.Nutrition;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logs.Web.Tests.ViewModelsTests.Nutrition.NutritionStatsViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange, Act
            var model = new NutritionStatsViewModel();

            // Assert
            Assert.IsNotNull(model);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetCaloriesCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            var list = new List<global::Logs.Models.Nutrition> { nutrition };

            var expected = list.Select(m => m.Calories);

            // Act
            var model = new NutritionStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Calories);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetProteinCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            var list = new List<global::Logs.Models.Nutrition> { nutrition };

            var expected = list.Select(m => m.Protein);

            // Act
            var model = new NutritionStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Protein);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetCarbsCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            var list = new List<global::Logs.Models.Nutrition> { nutrition };

            var expected = list.Select(m => m.Carbs);

            // Act
            var model = new NutritionStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Carbs);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetFatsCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            var list = new List<global::Logs.Models.Nutrition> { nutrition };

            var expected = list.Select(m => m.Fats);

            // Act
            var model = new NutritionStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Fats);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetFiberCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            var list = new List<global::Logs.Models.Nutrition> { nutrition };

            var expected = list.Select(m => m.Fiber);

            // Act
            var model = new NutritionStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Fiber);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetWaterInLitresCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            var list = new List<global::Logs.Models.Nutrition> { nutrition };

            var expected = list.Select(m => m.WaterInLitres);

            // Act
            var model = new NutritionStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.WaterInLitres);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetSugarCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            var list = new List<global::Logs.Models.Nutrition> { nutrition };

            var expected = list.Select(m => m.Sugar);

            // Act
            var model = new NutritionStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Sugar);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetDatesCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            var list = new List<global::Logs.Models.Nutrition> { nutrition };

            var expected = list.Select(m => m.Date.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture));

            // Act
            var model = new NutritionStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Dates);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetListModelCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);
            var nutrition = new global::Logs.Models.Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            var list = new List<global::Logs.Models.Nutrition> { nutrition };

            var expected = list.Select(m => new DateIdViewModel(m.NutritionId,
                m.Date.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)))
                .Reverse();

            // Act
            var model = new NutritionStatsViewModel(list);

            // Assert
            CollectionAssert.AllItemsAreNotNull(model.ListModel);
        }
    }
}
