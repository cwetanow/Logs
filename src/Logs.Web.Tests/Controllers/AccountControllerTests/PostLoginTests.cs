using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Factories;
using Logs.Web.Controllers;
using Logs.Web.Models.Account;
using Microsoft.AspNet.Identity.Owin;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Controllers.AccountControllerTests
{
    [TestFixture]
    public class PostLoginTests
    {
        [TestCase("pesho", "1234qwerty", true)]
        [TestCase("pesho", "1234qwerty", false)]
        public void TestPostLogin_ModelStateIsNotValid_ShouldReturnViewWithModel(string username,
            string password,
            bool remember)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = username,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);
            controller.ModelState.AddModelError("key", "error");

            // Act
            var result = controller.Login(model, "") as ViewResult;

            // Assert
            Assert.AreSame(model, result.Model);
        }

        [TestCase("pesho", "1234qwerty", true, "url")]
        [TestCase("pesho", "1234qwerty", false, "return url")]
        public void TestPostLogin_ModelStateIstValid_ShouldCallProviderSignInWithPassword(string username,
           string password,
           bool remember,
           string returnUrl)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = username,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Login(model, returnUrl);

            // Assert
            mockedProvider.Verify(p => p.SignInWithPassword(username, password, remember, It.IsAny<bool>()), Times.Once);
        }

        [TestCase("pesho", "1234qwerty", true, "url")]
        [TestCase("pesho", "1234qwerty", false, "return url")]
        public void TestPostLogin_ProviderReturnsSuccess_ShouldReturnRedirectResultWithCorrectUrl(string username,
           string password,
           bool remember,
           string returnUrl)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(SignInStatus.Success);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = username,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Login(model, returnUrl) as RedirectResult;

            // Assert
            Assert.AreEqual(returnUrl, result.Url);
        }

        [TestCase("pesho", "1234qwerty", true, null)]
        [TestCase("pesho", "1234qwerty", false, null)]
        public void TestPostLogin_SuccessReturnUrlIsEmty_ShouldReturnRedirectResultWithHomeIndex(string username,
           string password,
           bool remember,
           string returnUrl)
        {
            // Arrange
            var expectedUrl = "/Home/Index";

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(SignInStatus.Success);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = username,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Login(model, returnUrl) as RedirectResult;

            // Assert
            Assert.AreEqual(expectedUrl, result.Url);
        }

        [TestCase("pesho", "1234qwerty", true, "url")]
        [TestCase("pesho", "1234qwerty", false, "return url")]
        public void TestPostLogin_ProviderReturnsLockedOut_ShouldReturnLockoutView(string username,
           string password,
           bool remember,
           string returnUrl)
        {
            // Arrange
            var lockoutViewName = "Lockout";

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(SignInStatus.LockedOut);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = username,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Login(model, returnUrl) as ViewResult;

            // Assert
            Assert.AreEqual(lockoutViewName, result.ViewName);
        }

        [TestCase("pesho", "1234qwerty", true, "url")]
        [TestCase("pesho", "1234qwerty", false, "return url")]
        public void TestPostLogin_ProviderReturnsFailure_ShouldAddModelError(string username,
           string password,
           bool remember,
           string returnUrl)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(SignInStatus.Failure);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = username,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Login(model, returnUrl);

            // Assert
            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestCase("pesho", "1234qwerty", true, "url")]
        [TestCase("pesho", "1234qwerty", false, "return url")]
        public void TestPostLogin_ProviderReturnsFailure_ShouldReturnViewWithModel(string username,
           string password,
           bool remember,
           string returnUrl)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(SignInStatus.Failure);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Username = username,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Login(model, returnUrl) as ViewResult;

            // Assert
            Assert.AreEqual(model, result.Model);
        }
    }
}
