using Logs.Web.Models.Nutrition;
using NUnit.Framework;
using System;

namespace Logs.Web.Tests.ViewModelsTests.Nutrition.InputViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldSetDateCorrectly()
        {
            // Arrange
            var date = new DateTime();

            // Act
            var model = new InputViewModel(date);

            // Assert
            Assert.AreEqual(date, model.Date);
        }
    }
}
