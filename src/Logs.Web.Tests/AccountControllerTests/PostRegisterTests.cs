using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Web.Controllers;
using Logs.Web.Models.Account;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.AccountControllerTests
{
    [TestFixture]
    public class PostRegisterTests
    {
        [TestCase("pesho@pesho.com", "pesho", "1234qwerty")]
        public void TestPostRegister_ModelStateIsValid_ShouldCallUserFactoryCreateUserCorrectly(string email, string username, string password)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Success);

            var mockedFactory = new Mock<IUserFactory>();

            var model = new RegisterViewModel
            {
                Email = email,
                Username = username,
                Password = password
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Register(model);

            // Assert
            mockedFactory.Verify(f => f.CreateUser(username, email), Times.Once);
        }

        [TestCase("pesho@pesho.com", "pesho", "1234qwerty")]
        public void TestPostRegister_ModelStateIsValid_ShouldCallProviderRegisterAndLoginUserCorrectly(string email,
            string username,
            string password)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Success);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            var model = new RegisterViewModel
            {
                Email = email,
                Username = username,
                Password = password
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Register(model);

            // Assert
            mockedProvider.Verify(p => p.RegisterAndLoginUser(user, password, It.IsAny<bool>(), It.IsAny<bool>()));
        }

        [TestCase("pesho@pesho.com", "pesho", "1234qwerty")]
        public void TestPostRegister_ResultSuccess_ShouldReturnRedirectToRouteResult(string email,
            string username,
            string password)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Success);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            var model = new RegisterViewModel
            {
                Email = email,
                Username = username,
                Password = password
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Register(model);

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }

        [TestCase("pesho@pesho.com", "pesho", "1234qwerty")]
        public void TestPostRegister_ResultNotSuccess_ShouldReturnView(string email,
            string username,
            string password)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Failed(null));

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            var model = new RegisterViewModel
            {
                Email = email,
                Username = username,
                Password = password
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Register(model);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [TestCase("pesho@pesho.com", "pesho", "1234qwerty")]
        public void TestPostRegister_ResultNotSuccess_ShouldSetViewModelCorrectly(string email,
            string username,
            string password)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Failed(null));

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            var model = new RegisterViewModel
            {
                Email = email,
                Username = username,
                Password = password
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.Register(model) as ViewResult;

            // Assert
            Assert.AreSame(model, result.Model);
        }

        [TestCase("pesho@pesho.com", "pesho", "1234qwerty")]
        public void TestPostRegister_ModelsStateIsNotValid_ShouldReturnView(string email,
            string username,
            string password)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Success);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            var model = new RegisterViewModel
            {
                Email = email,
                Username = username,
                Password = password
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);
            controller.ModelState.AddModelError("key", "message");

            // Act
            var result = controller.Register(model);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [TestCase("pesho@pesho.com", "pesho", "1234qwerty")]
        public void TestPostRegister_ModelStateIsNotValid_ShouldSetViewModelCorrectly(string email,
            string username,
            string password)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(
                    p =>
                        p.RegisterAndLoginUser(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(),
                            It.IsAny<bool>()))
                .Returns(IdentityResult.Success);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
               .Returns(user);

            var model = new RegisterViewModel
            {
                Email = email,
                Username = username,
                Password = password
            };

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);
            controller.ModelState.AddModelError("key", "message");

            // Act
            var result = controller.Register(model) as ViewResult;

            // Assert
            Assert.AreSame(model, result.Model);
        }
    }
}
