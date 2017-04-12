using System.Collections.Generic;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.ListControllerTests
{
    [TestFixture]
    public class LatestTests
    {
        [TestCase(1)]
        [TestCase(423)]
        public void TestLatest_PassCount_ShouldCallLogServiceGetLatestLogsCorrectly(int count)
        {
            // Assert
            var mockedLogService = new Mock<ILogService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ListController(mockedLogService.Object,
               mockedFactory.Object);

            // Act
            controller.Latest(count);

            // Assert
            mockedLogService.Verify(s => s.GetLatestLogs(count), Times.Once);
        }

        [TestCase(1)]
        [TestCase(423)]
        public void TestLatest_PassCount_ShoudSetCorrectModel(int count)
        {
            // Assert
            var logs = new List<TrainingLog> { new TrainingLog() };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetLatestLogs(It.IsAny<int>())).Returns(logs);

            var mockedFactory = new Mock<IViewModelFactory>();

            var viewModel = new ShortLogViewModel();
            mockedFactory.Setup(f => f.CreateShortLogViewModel(It.IsAny<TrainingLog>())).Returns(viewModel);

            var model = new List<ShortLogViewModel> { viewModel };

            var controller = new ListController(mockedLogService.Object,  
                   mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Latest(count))
                .ShouldRenderPartialView("_LogListPartial")
                .WithModel<IEnumerable<ShortLogViewModel>>(m => CollectionAssert.AreEqual(model, m));
        }
    }
}
