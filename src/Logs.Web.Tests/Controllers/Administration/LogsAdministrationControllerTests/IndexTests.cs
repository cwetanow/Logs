using System.Collections.Generic;
using System.Web.Mvc;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;
using PagedList;

namespace Logs.Web.Tests.Controllers.Administration.LogsAdministrationControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void TestIndex_ShouldCallServiceGetAll()
        {
            // Arrange
            var mockedService = new Mock<ILogService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new LogsAdministrationController(mockedService.Object, mockedFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedService.Verify(s => s.GetAll(), Times.Once);
        }

        [TestCase(1, 1)]
        [TestCase(4, 2)]
        public void TestIndex_ShouldSetViewModelCorrectly(int page, int count)
        {
            // Arrange
            var logs = new List<TrainingLog> { new TrainingLog() };

            var mockedService = new Mock<ILogService>();
            mockedService.Setup(s => s.GetAll()).Returns(logs);

            var model = new ShortLogViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateShortLogViewModel(It.IsAny<TrainingLog>())).Returns(model);

            var controller = new LogsAdministrationController(mockedService.Object, mockedFactory.Object);

            var expectedList = new List<ShortLogViewModel> { model }
            .ToPagedList(page, count);

            // Act
            var result = controller.Index(page, count) as ViewResult;

            // Assert
            CollectionAssert.AreEqual(expectedList, (IPagedList<ShortLogViewModel>)result.Model);
        }
    }
}
