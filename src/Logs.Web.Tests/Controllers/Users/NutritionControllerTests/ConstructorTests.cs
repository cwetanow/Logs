using Logs.Services.Contracts;
using Logs.Web.Areas.Users.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using System;

namespace Logs.Web.Tests.Controllers.Users.NutritionControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act
            var controller = new NutritionController(mockedService.Object, mockedFactory.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new NutritionController(null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassViewModelFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedService = new Mock<IUserService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new NutritionController(mockedService.Object, null));
        }
    }
}
