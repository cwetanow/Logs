using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.NutritionControllerTests
{
    [TestFixture]
    public class StatsTests
    {
        [Test]
        public void TestStats_ShouldCallAuthenticationProviderCurrentUserId()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats();

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestStats_ShouldCallNutritionServiceGetUserNutritionsSortedByDate(string userId)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
                mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats();

            // Assert
            mockedNutritionService.Verify(s => s.GetUserNutritionsSortedByDate(userId), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestStats_ShouldCallFactoryCreateNutritionStatsViewModel(string userId)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var Nutritions = new List<Nutrition> { new Nutrition(), new Nutrition() };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.GetUserNutritionsSortedByDate(It.IsAny<string>())).Returns(Nutritions);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
               mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Stats();

            // Assert
            mockedFactory.Verify(f => f.CreateNutritionStatsViewModel(Nutritions), Times.Once);
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

            // Act
            controller.Stats();

            // Assert
            controller
                .WithCallTo(c => c.Stats())
                .ShouldRenderDefaultPartialView()
                .WithModel<NutritionStatsViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
