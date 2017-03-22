using System.Web.Mvc;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Controllers.Administration.LogsAdministrationControllerTests
{
    [TestFixture]
    public class DeleteTests
    {
        [TestCase(1)]
        [TestCase(43)]
        [TestCase(2)]
        public void TestDelete_ShouldCallServiceDeleteLog(int logId)
        {
            // Arrange
            var mockedService = new Mock<ILogService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsAdministrationController(mockedService.Object, mockedFactory.Object);

            // Act
            controller.Delete(logId);

            // Assert
            mockedService.Verify(s => s.DeleteLog(logId), Times.Once);
        }

        [TestCase(1)]
        [TestCase(43)]
        [TestCase(2)]
        public void TestDelete_ShouldReturnCorrectRedirectToRouteResult(int logId)
        {
            // Arrange
            var mockedService = new Mock<ILogService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsAdministrationController(mockedService.Object, mockedFactory.Object);

            // Act
            var result = controller.Delete(logId);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
    }
}
