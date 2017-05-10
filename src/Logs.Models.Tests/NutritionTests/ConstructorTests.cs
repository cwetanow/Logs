using NUnit.Framework;

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

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_ShouldSetCaloriesCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange, Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null);

            // Assert
            Assert.AreEqual(calories, nutrition.Calories);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_ShouldSetProteinCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange, Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null);

            // Assert
            Assert.AreEqual(protein, nutrition.Protein);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_ShouldSetCarbsCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange, Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null);

            // Assert
            Assert.AreEqual(carbs, nutrition.Carbs);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_ShouldSetFatsCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange, Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null);

            // Assert
            Assert.AreEqual(fats, nutrition.Fats);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_ShouldSetWaterInLitresCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange, Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null);

            // Assert
            Assert.AreEqual(water, nutrition.WaterInLitres);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_ShouldSetFiberCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange, Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null);

            // Assert
            Assert.AreEqual(fiber, nutrition.Fiber);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_ShouldSetSugarCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange, Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null);

            // Assert
            Assert.AreEqual(sugar, nutrition.Sugar);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_ShouldSetNotesCorrectly(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange, Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null);

            // Assert
            Assert.AreEqual(notes, nutrition.Notes);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_EntryIsNull_EntryIdShouldBeDefault(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange,
            var expected = default(int);

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, null);

            // Assert
            Assert.AreEqual(expected, nutrition.EntryId);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(14, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestConstructor_ShouldSetEntryIdCorrectly(int entryId, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange,
            var entry = new NutritionEntry { NutritionEntryId = entryId };

            // Act
            var nutrition = new Nutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, entry);

            // Assert
            Assert.AreEqual(entryId, nutrition.EntryId);
        }
    }
}
