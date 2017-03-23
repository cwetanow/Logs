using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.ProfileControllerTests
{
    [TestFixture]
    public class NoLogTests
    {
        [Test]
        public void TestNoLog_ShouldReturnView()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.NoLog())
                .ShouldRenderDefaultView();
        }
    }
}
