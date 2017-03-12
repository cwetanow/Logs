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
using PagedList;

namespace Logs.Web.Tests.LogsControllerTests
{
    [TestFixture]
    public class ListTests
    {
        [Test]
        public void TestList_ShouldReturnCorrectView()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCachingProvider = new Mock<ICachingProvider>();

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
               mockedFactory.Object);
            // Act
            var result = controller.List();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
