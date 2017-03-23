using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.LogsControllerTests
{
    [TestFixture]
    public class PostCreateTests
    {
        [TestCase(1, "name", "description", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "lala name", "my description", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreate_ShouldCallAuthenticationProviderCurrentUserId(int logId, string name,
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

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act
            controller.Create(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [Test]
        public void TestCreate_ModelStateIsNotValid_ShouldReturnViewWithModel()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var model = new CreateLogViewModel();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
               mockedFactory.Object);
            controller.ModelState.AddModelError("key", "value");

            // Act, Assert
            controller
                .WithCallTo(c => c.Create(model))
                .ShouldRenderDefaultView()
                .WithModel<CreateLogViewModel>(m => Assert.AreSame(model, m));
        }

        [TestCase(1, "name", "description", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "lala name", "my description", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreate_ShouldCallLogServiceCreateTrainingLog(int logId, string name,
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

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
               mockedFactory.Object);

            // Act
            controller.Create(model);

            // Assert
            mockedLogService.Verify(p => p.CreateTrainingLog(name, description, userId), Times.Once);
        }

        [TestCase(1, "name", "description", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "lala name", "my description", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreate_ShouldSetDetailsViewIdCorrectly(int logId, string name,
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

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                 mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Create(model))
                .ShouldRedirectTo((LogsController c) => c.Details(logId, It.IsAny<int>(), It.IsAny<int>()));
        }
    }
}
