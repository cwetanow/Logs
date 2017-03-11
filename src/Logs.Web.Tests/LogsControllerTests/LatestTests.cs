using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.LogsControllerTests
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
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act
            controller.Latest(count);

            // Assert
            mockedLogService.Verify(s => s.GetLatestLogs(count), Times.Once);
        }

        [TestCase(1)]
        [TestCase(423)]
        public void TestLatest_PassCount_ShoudReturnLogListPartialView(int count)
        {
            // Assert
            var expectedViewName = "_LogListPartial";

            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
                mockedFactory.Object);

            // Act
            var result = controller.Latest(count) as PartialViewResult;

            // Assert
            Assert.AreEqual(expectedViewName, result.ViewName);
        }
    }
}
