using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Controllers;
using Logs.Web.Models.Logs;
using Moq;
using NUnit.Framework;
using PagedList;

namespace Logs.Web.Tests.Administration.LogsAdministrationControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void TestIndex_ShouldCallServiceGetAll()
        {
            // Arrange
            var mockedService = new Mock<ILogService>();

            var controller = new LogsAdministrationController(mockedService.Object);

            // Act
            controller.Index();

            // Assert
            mockedService.Verify(s => s.GetAll(), Times.Once);
        }
    }
}
