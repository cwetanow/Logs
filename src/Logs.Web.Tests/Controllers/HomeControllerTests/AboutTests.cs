using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class AboutTests
    {
        [Test]
        public void TestAbout_ShouldReturnView()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var controller = new HomeController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.About())
                .ShouldRenderDefaultView();
        }
    }
}
