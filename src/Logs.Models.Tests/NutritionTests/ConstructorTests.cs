using NUnit.Framework;
using System;

namespace Logs.Models.Tests.NutritionTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange, Act
            var nutrition = new Nutrition();

            // Assert
            Assert.IsNotNull(nutrition);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetCaloriesCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreEqual(calories, nutrition.Calories);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetProteinCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreEqual(protein, nutrition.Protein);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetCarbsCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreEqual(carbs, nutrition.Carbs);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetFatsCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreEqual(fats, nutrition.Fats);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetWaterCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreEqual(water, nutrition.WaterInLitres);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetFiberCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreEqual(fiber, nutrition.Fiber);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetSugarCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreEqual(sugar, nutrition.Sugar);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetNotesCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreEqual(notes, nutrition.Notes);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetUserIdCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreEqual(userId, nutrition.UserId);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetDateCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date);

            // Assert
            Assert.AreEqual(date, nutrition.Date);
        }
    }
}
