using Logs.Web.Models.Nutrition;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Nutrition.DateIdViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase(1, "formated date")]
        [TestCase(171, "another formated date")]
        [TestCase(3, "look, a formated date")]
        public void TestConstructor_ShouldSetIdCorrectly(int id, string formatedDate)
        {
            // Arrange, Act
            var model = new DateIdViewModel(id, formatedDate);

            // Assert
            Assert.AreEqual(id, model.Id);
        }

        [TestCase(1, "formated date")]
        [TestCase(171, "another formated date")]
        [TestCase(3, "look, a formated date")]
        public void TestConstructor_ShouldSetDateCorrectly(int id, string formatedDate)
        {
            // Arrange, Act
            var model = new DateIdViewModel(id, formatedDate);

            // Assert
            Assert.AreEqual(formatedDate, model.FormattedDate);
        }

        [TestCase(1, "formated date")]
        [TestCase(171, "another formated date")]
        [TestCase(3, "look, a formated date")]
        public void TestConstructor_ShouldInitializeCorrectly(int id, string formatedDate)
        {
            // Arrange, Act
            var model = new DateIdViewModel(id, formatedDate);

            // Assert
            Assert.IsNotNull(model);
        }
    }
}
