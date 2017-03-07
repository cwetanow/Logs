using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Factories;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.AccountControllerTests
{
    [TestFixture]
    public class LoginTests
    {
        [TestCase("home.com")]
        [TestCase("about.com")]
        public void TestLogin_ShouldReturnView(string returnUrl)
        {
            // Assert
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Login(returnUrl);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [TestCase("home.com")]
        [TestCase("about.com")]
        public void TestLogin_ShouldSetViewBagReturnUrl(string returnUrl)
        {
            // Assert
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Login(returnUrl) as ViewResult;

            // Assert
            Assert.AreEqual(returnUrl, result.ViewBag.ReturnUrl);
        }
    }
}
