using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.NutritionControllerTests
{
    [TestFixture]
    public class StatsTests
    {
        [Test]
        public void TestStats_NoIdProvided_ShouldCallAuthenticationIsAuthenticated()
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats(null);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.IsAuthenticated, Times.Once);
        }

        [Test]
        public void TestStats_NoIdProvidedAndIsAuthenticated_ShouldCallAuthenticationProviderCurrentUserId()
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.IsAuthenticated).Returns(true);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats(null);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [Test]
        public void TestStats_NoIdProvidedAndIsAuthenticated_ShouldSetModelCanDeleteToTrue()
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.IsAuthenticated).Returns(true);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats(null);

            // Assert
            Assert.IsTrue(model.CanDelete);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestStats_WithId_ShouldNotCallAuthenticationProviderCurrentUserId(string userId)
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats(userId);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Never);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestStats_IsNotAuthenticated_ShouldNotCallAuthenticationProviderCurrentUserId(string userId)
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats(userId);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Never);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestStats_IsNotAuthenticated_ShouldSetModelCanDeleteToFalse(string userId)
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats(userId);

            // Assert
            Assert.IsFalse(model.CanDelete);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestStats_WithoutIdAndIsAuthenticated_ShouldCallNutritionServiceGetUserNutritionsSortedByDate(string userId)
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);
            mockedAuthenticationProvider.Setup(p => p.IsAuthenticated).Returns(true);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats(null);

            // Assert
            mockedNutritionService.Verify(s => s.GetUserNutritionsSortedByDate(userId), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestStats_WithoutIdAndIsNotAuthenticated_ShouldCallNutritionServiceGetUserNutritionsSortedByDateWithNull(string userId)
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats(null);

            // Assert
            mockedNutritionService.Verify(s => s.GetUserNutritionsSortedByDate(null), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestStats_WithId_ShouldCallNutritionServiceGetUserNutritionsSortedByDate(string userId)
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats(userId);

            // Assert
            mockedNutritionService.Verify(s => s.GetUserNutritionsSortedByDate(userId), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestStats_ShouldCallFactoryCreateNutritionStatsViewModel(string userId)
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutritions = new List<Nutrition> { new Nutrition(), new Nutrition() };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.GetUserNutritionsSortedByDate(It.IsAny<string>())).Returns(nutritions);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
               mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats(null);

            // Assert
            mockedFactory.Verify(f => f.CreateNutritionStatsViewModel(nutritions), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestStats_ShouldRenderDefaultViewWithCorrectModel(string userId)
        {
            // Arrange
            var model = new NutritionStatsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionStatsViewModel(It.IsAny<IEnumerable<Nutrition>>())).Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
               mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Stats(null))
                .ShouldRenderDefaultPartialView()
                .WithModel<NutritionStatsViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
