using System.Collections.Generic;
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
    public class TopLogsTests
    {
        [TestCase(1)]
        [TestCase(423)]
        public void TestTopLogs_PassCount_ShouldCallLogServiceGetTopLogsCorrectly(int count)
        {
            // Assert
            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                 mockedFactory.Object);

            // Act
            controller.TopLogs(count);

            // Assert
            mockedLogService.Verify(s => s.GetTopLogs(count), Times.Once);
        }

        [TestCase(1)]
        [TestCase(423)]
        public void TestTopLogs_PassCount_ShoudReturnLogListPartialView(int count)
        {
            // Assert
            var expectedViewName = "_LogListPartial";

            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act
            var result = controller.TopLogs(count) as PartialViewResult;

            // Assert
            Assert.AreEqual(expectedViewName, result.ViewName);
        }

        [TestCase(1)]
        [TestCase(423)]
        public void TestTopLogs_PassCount_ShoudSetCorrectModel(int count)
        {
            // Assert
            var logs = new List<TrainingLog> { new TrainingLog() };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetTopLogs(It.IsAny<int>())).Returns(logs);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var viewModel = new ShortLogViewModel();
            mockedFactory.Setup(f => f.CreateShortLogViewModel(It.IsAny<TrainingLog>())).Returns(viewModel);

            var model = new List<ShortLogViewModel> { viewModel };

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act
            var result = controller.TopLogs(count) as PartialViewResult;

            // Assert
            CollectionAssert.AreEqual(model, (IEnumerable<ShortLogViewModel>)result.Model);
        }
    }
}
