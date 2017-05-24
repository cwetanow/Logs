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
    public class GetMeasurementTests
    {
        [TestCase(1)]
        [TestCase(6)]
        [TestCase(1457)]
        [TestCase(13)]
        public void TestGetMeasurement_ShouldCallSeasurementServiceGetById(int id)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
            mockedMeasurementService.Object, mockedFactory.Object);

            // Act
            controller.GetMeasurement(id);

            // Assert
            mockedMeasurementService.Verify(s => s.GetById(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(1457)]
        [TestCase(13)]
        public void TestGetMeasurement_ServiceReturnsNull_ShouldRenderPartialViewWithModelNull(int id)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
            mockedMeasurementService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.GetMeasurement(id))
                .ShouldRenderPartialView("MeasurementDetails");
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(1457)]
        [TestCase(13)]
        public void TestGetMeasurement_ServiceReturnsMeasurement_ShouldCallFactoryCreateMeasurementViewModel(int id)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);

            var measurement = new Measurement { Date = date };

            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedMeasurementService = new Mock<IMeasurementService>();
            mockedMeasurementService.Setup(s => s.GetById(It.IsAny<int>())).Returns(measurement);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
            mockedMeasurementService.Object, mockedFactory.Object);

            // Act
            controller.GetMeasurement(id);

            // Assert
            mockedFactory.Verify(f => f.CreateMeasurementViewModel(measurement, date), Times.Once);
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(1457)]
        [TestCase(13)]
        public void TestGetMeasurement_ServiceReturnsMeasurement_ShouldRenderPartialViewWithModel(int id)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);

            var measurement = new Measurement { Date = date };

            var model = new MeasurementViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedMeasurementService = new Mock<IMeasurementService>();
            mockedMeasurementService.Setup(s => s.GetById(It.IsAny<int>())).Returns(measurement);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
            mockedMeasurementService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.GetMeasurement(id))
                .ShouldRenderPartialView("MeasurementDetails")
                .WithModel<MeasurementViewModel>(model);
        }
    }
}
