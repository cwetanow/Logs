using System;
using Logs.Authentication.Contracts;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Controllers.NutritionControllerTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            // Act
            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new NutritionController(null,
                mockedDateTimeProvider.Object,
                mockedNutritionService.Object,
                mockedAuthenticationProvider.Object));
        }

        [Test]
        public void TestConstructor_PassDateTimeProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new NutritionController(mockedFactory.Object,
                null,
                mockedNutritionService.Object,
                mockedAuthenticationProvider.Object));
        }

        [Test]
        public void TestConstructor_PassNutritionServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new NutritionController(mockedFactory.Object,
                mockedDateTimeProvider.Object,
                null,
                mockedAuthenticationProvider.Object));
        }

        [Test]
        public void TestConstructor_PassAuthenticationProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new NutritionController(mockedFactory.Object,
                mockedDateTimeProvider.Object,
                mockedNutritionService.Object,
                null));
        }
    }
}
