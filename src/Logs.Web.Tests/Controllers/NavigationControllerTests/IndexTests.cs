using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Navigation;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.NavigationControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void TestIndex_ShouldCallAuthProviderIsAuthenticated()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthProvider.Verify(p => p.IsAuthenticated, Times.Once);
        }

        [Test]
        public void TestIndex_AuthProviderIsAuthenticatedReturnsFalse_ShouldNotCallAuthProviderCurrentUserId()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthProvider.Verify(p => p.CurrentUserId, Times.Never);
        }

        [Test]
        public void TestIndex_AuthProviderIsAuthenticatedReturnsFalse_ShouldCallFactoryCreateCorrectly()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            var expectedIsAuthenticated = false;
            var expectedIsAdmin = false;
            var expectedUsername = string.Empty;

            // Act
            controller.Index();

            // Assert
            mockedViewModelFactory.Verify(f => f.CreateNavigationViewModel(expectedUsername, expectedIsAuthenticated, expectedIsAdmin),
                Times.Once);
        }

        [Test]
        public void TestIndex_AuthProviderIsAuthenticatedReturnsTrue_ShouldCallAuthProviderCurrentUserId()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            mockedAuthProvider.Setup(p => p.IsAuthenticated).Returns(true);

            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [Test]
        public void TestIndex_AuthProviderIsAuthenticatedReturnsTrue_ShouldCallAuthProviderCurrentUserUsername()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            mockedAuthProvider.Setup(p => p.IsAuthenticated).Returns(true);

            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthProvider.Verify(p => p.CurrentUserUsername, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestIndex_AuthProviderIsAuthenticatedReturnsTrue_ShouldCallAuthProviderIsInRoleCorrectly(string userId)
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();
            mockedAuthProvider.Setup(p => p.CurrentUserId).Returns(userId);
            mockedAuthProvider.Setup(p => p.IsAuthenticated).Returns(true);

            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedAuthProvider.Verify(p => p.IsInRole(userId, It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void TestIndex_ShouldSetCorrectViewModel()
        {
            // Arrange
            var mockedAuthProvider = new Mock<IAuthenticationProvider>();

            var model = new NavigationViewModel();

            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(
                    f => f.CreateNavigationViewModel(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns(model);

            var controller = new NavigationController(mockedAuthProvider.Object, mockedViewModelFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderPartialView("Navigation")
                .WithModel<NavigationViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
