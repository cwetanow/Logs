﻿using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Factories;
using Logs.Web.Controllers;
using Logs.Web.Models.Account;
using Microsoft.AspNet.Identity.Owin;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

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

            // Act, Assert
            controller
                .WithCallTo(c => c.Login(model, ""))
                .ShouldRenderDefaultView()
                .WithModel<LoginViewModel>(m => Assert.AreSame(model, m));
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

            // Act, Assert
            controller
                .WithCallTo(c => c.Login(model, returnUrl))
                .ShouldRedirectTo(returnUrl);
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

            // Act, Assert
            controller
                .WithCallTo(c => c.Login(model, returnUrl))
                .ShouldRedirectTo(expectedUrl);
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

            // Act, Assert
            controller
                .WithCallTo(c => c.Login(model, returnUrl))
                .ShouldRenderView(lockoutViewName);
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

            // Act, Assert
            controller
                .WithCallTo(c => c.Login(model, returnUrl))
                .ShouldRenderDefaultView()
                .WithModel<LoginViewModel>(m =>
                {
                    Assert.AreSame(model, m);
                });
        }
    }
}
