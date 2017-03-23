using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.LogsControllerTests
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

            var controller = new LogsController(mockedLogService.Object, mockedAuthenticationProvider.Object,
               mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.List())
                .ShouldRenderDefaultView();
        }
    }
}
