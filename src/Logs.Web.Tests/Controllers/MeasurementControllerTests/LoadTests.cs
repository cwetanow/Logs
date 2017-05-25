using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;
using Moq;
using NUnit.Framework;
using System;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.MeasurementControllerTests
{

    [TestFixture]
    public class LoadTests
    {
        [Test]
        public void TestLoad_ModelStateIsNotValid_ShouldRenderCorrectView()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
            mockedMeasurementService.Object, mockedFactory.Object);
            controller.ModelState.AddModelError("", "");

            // Act, Assert
            controller
                .WithCallTo(c => c.Load(new InputViewModel()))
                .ShouldRenderDefaultPartialView();
        }

        [Test]
        public void TestLoad_ModelStateIsValid_ShouldCallAuthenticationProviderCurrentUserId()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
           mockedMeasurementService.Object, mockedFactory.Object);

            // Act
            controller.Load(new InputViewModel());

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestLoad_ModelStateIsValid_ShouldCallMeasurementServiceGetByDate(string userId)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
            mockedMeasurementService.Object, mockedFactory.Object);

            // Act
            controller.Load(model);

            // Assert
            mockedMeasurementService.Verify(s => s.GetByDate(userId, date), Times.Once);
        }

        [Test]
        public void TestLoad_MeasurementIsNull_ShouldCallFactoryCreateNutritonViewModelWithNull()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
            mockedMeasurementService.Object, mockedFactory.Object);

            // Act
            controller.Load(model);

            // Assert
            mockedFactory.Verify(f => f.CreateMeasurementViewModel(null, date));
        }

        [Test]
        public void TestLoad_MeasurementIsNotNull_ShouldCallFactoryCreatMeasurementViewModelCorrectly()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var Measurement = new Measurement();

            var mockedMeasurementService = new Mock<IMeasurementService>();
            mockedMeasurementService.Setup(s => s.GetByDate(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(Measurement);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
           mockedMeasurementService.Object, mockedFactory.Object);

            // Act
            controller.Load(model);

            // Assert
            mockedFactory.Verify(f => f.CreateMeasurementViewModel(Measurement, date));
        }

        [Test]
        public void TestLoad_ShouldRenderCorrectViewWithModel()
        {
            // Arrange
            var viewModel = new MeasurementViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(viewModel);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
           mockedMeasurementService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Load(model))
                .ShouldRenderDefaultPartialView()
                .WithModel<MeasurementViewModel>(m => Assert.AreSame(viewModel, m));
        }
    }
}