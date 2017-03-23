using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Home;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void TestIndex_ShouldCallProviderIsAuthenticated(bool isAuthenticated)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);

            var controller = new HomeController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedProvider.Verify(p => p.IsAuthenticated, Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestIndex_ShouldCallFactoryCreateCorrectly(bool isAuthenticated)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);

            var controller = new HomeController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Index();

            // Assert
            mockedFactory.Verify(f => f.CreateHomeViewModel(isAuthenticated), Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestIndex_ShouldReturnViewWithModel(bool isAuthenticated)
        {
            // Arrange
            var model = new HomeViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateHomeViewModel(It.IsAny<bool>())).Returns(model);

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);

            var controller = new HomeController(mockedProvider.Object, mockedFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<HomeViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
