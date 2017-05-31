using Logs.Authentication.Contracts;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Controllers.MeasurementControllerTests
{
    [TestFixture]
    public class DeleteMeasurementTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_ShouldCallAuthenticationProviderCurrentUserId(int id, string userId)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
            mockedMeasurementService.Object, mockedFactory.Object);

            // Act
            controller.DeleteMeasurement(id);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_ShouldCallMeasurementServiceDeleteMeasurement(int id, string userId)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
            mockedMeasurementService.Object, mockedFactory.Object);

            // Act
            controller.DeleteMeasurement(id);

            // Assert
            mockedMeasurementService.Verify(s => s.DeleteMeasurement(id, userId), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_ShouldReturnNull(int id, string userId)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
            mockedMeasurementService.Object, mockedFactory.Object);

            // Act
            var result = controller.DeleteMeasurement(id);

            // Assert
            Assert.IsNull(result);
        }
    }
}
