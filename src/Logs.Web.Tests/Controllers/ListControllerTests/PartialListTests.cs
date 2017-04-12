using System.Collections.Generic;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;
using PagedList;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.ListControllerTests
{
    [TestFixture]
    public class PartialListTests
    {
        [Test]
        public void TestPartialList_ShouldCallServiceGetAllSortedByDate()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ListController(mockedLogService.Object,  
                    mockedFactory.Object);

            // Act
            controller.PartialList();

            // Assert
            mockedLogService.Verify(s => s.GetAllSortedByDate(), Times.Once);
        }

        [Test]
        public void TestPartialList_ShouldSetCorrectViewModel()
        {
            // Arrange
            var logs = new List<TrainingLog> { new TrainingLog() };

            var mockedLogService = new Mock<ILogService>();
            mockedLogService.Setup(s => s.GetAllSortedByDate()).Returns(logs);

            var model = new ShortLogViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateShortLogViewModel(It.IsAny<TrainingLog>())).Returns(model);

            var controller = new ListController(mockedLogService.Object,  
                           mockedFactory.Object);

            var expectedList = new List<ShortLogViewModel> { model };

            // Act, Assert
            controller
                .WithCallTo(c => c.PartialList(1, 1))
                .ShouldRenderPartialView("_PagedLogListPartial")
                .WithModel<IPagedList<ShortLogViewModel>>(m => CollectionAssert.AreEqual(expectedList, m));
        }
    }
}
