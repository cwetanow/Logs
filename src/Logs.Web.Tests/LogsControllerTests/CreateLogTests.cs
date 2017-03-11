using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.LogsControllerTests
{
    [TestFixture]
    public class CreateLogTests
    {
        [TestCase(1, "name", "description", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "lala name", "my description", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateLog_ShouldCallAuthenticationProviderCurrentUserId(int logId, string name,
            string description, string userId)
        {
            // Arrange
            var log = new TrainingLog { LogId = logId };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.CreateTrainingLog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var model = new CreateLogViewModel { Description = description, Name = name };

            var mockedCachingProvider = new Mock<ICachingProvider>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object, mockedCachingProvider.Object);

            // Act
            controller.CreateLog(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase(1, "name", "description", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "lala name", "my description", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateLog_ShouldCallLogServiceCreateTrainingLog(int logId, string name,
            string description, string userId)
        {
            // Arrange
            var log = new TrainingLog { LogId = logId };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.CreateTrainingLog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedFactory = new Mock<IViewModelFactory>();

            var model = new CreateLogViewModel { Description = description, Name = name };

            var mockedCachingProvider = new Mock<ICachingProvider>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object, mockedCachingProvider.Object);

            // Act
            controller.CreateLog(model);

            // Assert
            mockedLogService.Verify(p => p.CreateTrainingLog(name, description, userId), Times.Once);
        }

        [TestCase(1, "name", "description", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "lala name", "my description", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateLog_ShouldCallCachingProviderRemoveItem(int logId, string name,
            string description, string userId)
        {
            // Arrange
            var log = new TrainingLog { LogId = logId };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.CreateTrainingLog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedFactory = new Mock<IViewModelFactory>();

            var model = new CreateLogViewModel { Description = description, Name = name };

            var mockedCachingProvider = new Mock<ICachingProvider>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object, mockedCachingProvider.Object);

            // Act
            controller.CreateLog(model);

            // Assert
            mockedCachingProvider.Verify(p => p.RemoveItem(It.IsAny<string>()), Times.Once);
        }

        [TestCase(1, "name", "description", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "lala name", "my description", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateLog_ShouldSetDetailsViewIdCorrectly(int logId, string name,
            string description, string userId)
        {
            // Arrange
            var log = new TrainingLog { LogId = logId };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.CreateTrainingLog(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(log);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedFactory = new Mock<IViewModelFactory>();

            var model = new CreateLogViewModel { Description = description, Name = name };

            var mockedCachingProvider = new Mock<ICachingProvider>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object, mockedCachingProvider.Object);

            // Act
            var result = controller.CreateLog(model);

            // Assert
            Assert.AreEqual(logId, result.RouteValues["id"]);
        }
    }
}
