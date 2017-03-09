using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Web.Controllers;
using Logs.Web.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.AccountControllerTests
{
    [TestFixture]
    public class PostLoginTests
    {
        [TestCase("pesho@pesho.com", "1234qwerty", true)]
        [TestCase("pesho@pesho.com", "1234qwerty", false)]
        public void TestPostLogin_ModelStateIsNotValid_ShouldReturnViewWithModel(string email,
            string password,
            bool remember)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Email = email,
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

        [TestCase("pesho@pesho.com", "1234qwerty", true, "url")]
        [TestCase("pesho@pesho.com", "1234qwerty", false, "return url")]
        public void TestPostLogin_ModelStateIstValid_ShouldCallProviderSignInWithPassword(string email,
           string password,
           bool remember,
           string returnUrl)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedFactory = new Mock<IUserFactory>();

            var model = new LoginViewModel()
            {
                Email = email,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Login(model, returnUrl);

            // Assert
            mockedProvider.Verify(p => p.SignInWithPassword(email, password, remember, It.IsAny<bool>()), Times.Once);
        }

        [TestCase("pesho@pesho.com", "1234qwerty", true, "url")]
        [TestCase("pesho@pesho.com", "1234qwerty", false, "return url")]
        public void TestPostLogin_ProviderReturnsSuccess_ShouldReturnRedirectResultWithCorrectUrl(string email,
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
                Email = email,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Login(model, returnUrl) as RedirectResult;

            // Assert
            Assert.AreEqual(returnUrl, result.Url);
        }

        [TestCase("pesho@pesho.com", "1234qwerty", true, null)]
        [TestCase("pesho@pesho.com", "1234qwerty", false, null)]
        public void TestPostLogin_SuccessReturnUrlIsEmty_ShouldReturnRedirectResultWithHomeIndex(string email,
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
                Email = email,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Login(model, returnUrl) as RedirectResult;

            // Assert
            Assert.AreEqual(expectedUrl, result.Url);
        }

        [TestCase("pesho@pesho.com", "1234qwerty", true, "url")]
        [TestCase("pesho@pesho.com", "1234qwerty", false, "return url")]
        public void TestPostLogin_ProviderReturnsLockedOut_ShouldReturnLockoutView(string email,
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
                Email = email,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Login(model, returnUrl) as ViewResult;

            // Assert
            Assert.AreEqual(lockoutViewName, result.ViewName);
        }

        [TestCase("pesho@pesho.com", "1234qwerty", true, "url")]
        [TestCase("pesho@pesho.com", "1234qwerty", false, "return url")]
        public void TestPostLogin_ProviderReturnsFailure_ShouldAddModelError(string email,
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
                Email = email,
                Password = password,
                RememberMe = remember
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Login(model, returnUrl);

            // Assert
            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestCase("pesho@pesho.com", "1234qwerty", true, "url")]
        [TestCase("pesho@pesho.com", "1234qwerty", false, "return url")]
        public void TestPostLogin_ProviderReturnsFailure_ShouldReturnViewWithModel(string email,
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
                Email = email,
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
