using System;
using Logs.Authentication.Contracts;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.NutritionControllerTests
{
    [TestFixture]
    public class InputTests
    {
        [Test]
        public void TestInput_ShouldCallDateTimeProviderGetCurrentTime()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Input();

            // Assert
            mockedDateTimeProvider.Verify(p => p.GetCurrentTime(), Times.Once);
        }

        [Test]
        public void TestInput_ShouldCallFactoryCreateInputViewModelCorrectly()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();

            var date = new DateTime();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrentTime()).Returns(date);

            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Input();

            // Assert
            mockedFactory.Verify(f => f.CreateInputViewModel(date), Times.Once);
        }

        [Test]
        public void TestInput_ShouldRenderCorrectViewWithModel()
        {
            // Arrange
            var model = new InputViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateInputViewModel(It.IsAny<DateTime>())).Returns(model);

            var date = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrentTime()).Returns(date);

            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Input())
                .ShouldRenderDefaultView()
                .WithModel<InputViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
