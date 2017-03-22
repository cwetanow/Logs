using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Profile;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Controllers.ProfileControllerTests
{
    [TestFixture]
    public class DetailsTests
    {
        [TestCase("username")]
        [TestCase("my-username")]
        [TestCase("lalalala96")]
        public void TestDetails_ShouldCallServiceGetByUsername(string username)
        {
            // Arrange
            var user = new User();

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserByUsername(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act
            controller.Details(username);

            // Assert
            mockedService.Verify(s => s.GetUserByUsername(username), Times.Once);
        }

        [TestCase("username")]
        [TestCase("my-username")]
        [TestCase("lalalala96")]
        public void TestDetails_ShouldCallProviderCurrentUserId(string username)
        {
            // Arrange
            var user = new User();

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserByUsername(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act
            controller.Details(username);

            // Assert
            mockedProvider.Verify(s => s.CurrentUserId, Times.Once);
        }

        [TestCase("username")]
        [TestCase("my-username")]
        [TestCase("lalalala96")]
        public void TestDetails_ProviderReturnsCurrentUserIdNull_ShouldSetViewModelCanEditToFalse(string username)
        {
            // Arrange
            var user = new User();

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserByUsername(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateUserProfileViewModel(It.IsAny<User>(), It.IsAny<bool>()))
                .Returns((User u, bool canEdit) => new UserProfileViewModel(user, canEdit));

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act
            var result = controller.Details(username) as ViewResult;

            // Assert
            Assert.IsFalse(((UserProfileViewModel)result.Model).CanEdit);
        }

        [TestCase("username", "id")]
        [TestCase("my-username", "12")]
        [TestCase("lalalala96", "abcd-1234")]
        public void TestDetails_ProviderReturnsCurrentUserId_ShouldSetViewModelCanEditToCorrectly(string username, string userId)
        {
            // Arrange
            var user = new User { Id = userId };

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserByUsername(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateUserProfileViewModel(It.IsAny<User>(), It.IsAny<bool>()))
                .Returns((User u, bool canEdit) => new UserProfileViewModel(user, canEdit));

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            var expected = user.Id.Equals(userId);

            // Act
            var result = controller.Details(username) as ViewResult;

            // Assert
            Assert.AreEqual(expected, ((UserProfileViewModel)result.Model).CanEdit);
        }

        [TestCase("username")]
        [TestCase("my-username")]
        [TestCase("lalalala96")]
        public void TestDetails_ShouldCallViewModelFactoryCreateUserProfileCorrectly(string username)
        {
            // Arrange
            var user = new User();

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUserByUsername(It.IsAny<string>())).Returns(user);

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateUserProfileViewModel(It.IsAny<User>(), It.IsAny<bool>()))
                .Returns((User u, bool canEdit) => new UserProfileViewModel(user, canEdit));

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object, mockedFactory.Object);

            // Act
            var result = controller.Details(username) as ViewResult;

            // Assert
            mockedFactory.Verify(f => f.CreateUserProfileViewModel(user, It.IsAny<bool>()), Times.Once);
        }
    }
}
