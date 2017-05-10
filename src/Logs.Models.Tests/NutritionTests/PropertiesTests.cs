using NUnit.Framework;

namespace Logs.Models.Tests.NutritionTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(1)]
        [TestCase(999)]
        [TestCase(326)]
        [TestCase(1257)]
        [TestCase(73)]
        [TestCase(14)]
        public void TestNutritionId_ShouldInitializeCorrectly(int nutritionId)
        {
            // Arrange
            var nutrition = new Nutrition();

            // Act
            nutrition.NutritionId = nutritionId;

            // Assert
            Assert.AreEqual(nutritionId, nutrition.NutritionId);
        }

        [Test]
        public void TestNutritionEntry_ShouldInitializeCorrectly()
        {
            // Arrange
            var nutrition = new Nutrition();
            var entry = new NutritionEntry();

            // Act
            nutrition.NutritionEntry = entry;

            // Assert
            Assert.AreSame(entry, nutrition.NutritionEntry);
        }
    }
}
