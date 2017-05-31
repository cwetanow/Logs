using Logs.Authentication.Contracts;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Controllers.NutritionControllerTests
{
    [TestFixture]
    public class DeleteNutritionTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_ShouldCallAuthenticationProviderCurrentUserId(int id, string userId)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
               mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.DeleteNutrition(id);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_ShouldCallNutritionServiceDeleteNutrition(int id, string userId)
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
            controller.DeleteNutrition(id);

            // Assert
            mockedNutritionService.Verify(s => s.DeleteNutrition(id, userId), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_ShouldReturnNull(int id, string userId)
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
            var result = controller.DeleteNutrition(id);

            // Assert
            Assert.IsNull(result);
        }
    }
}
