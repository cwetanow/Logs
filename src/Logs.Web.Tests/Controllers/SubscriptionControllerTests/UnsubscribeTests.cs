using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Subscription;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.SubscriptionControllerTests
{
    [TestFixture]
    public class UnsubscribeTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnsubscribe_ShouldCallAuthProviderCurrentUserId(int logId, string userId)
        {
            // Arrange
            var mockedService = new Mock<ISubscriptionService>();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new SubscriptionController(mockedService.Object, mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Subscribe(logId);

            // Assert
            mockedProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnsubscribe_ShouldCallSubscriptionServiceUnsubscribe(int logId, string userId)
        {
            // Arrange
            var mockedService = new Mock<ISubscriptionService>();

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new SubscriptionController(mockedService.Object, mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Unsubscribe(logId);

            // Assert
            mockedService.Verify(s => s.Unsubscribe(logId, userId), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", true)]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa", false)]
        public void TestUnsubscribe_ShouldCallFactoryCreateSubscribeViewModelWithOppositeOfServiceResult(int logId, string userId, bool isSubscribed)
        {
            // Arrange
            var mockedService = new Mock<ISubscriptionService>();
            mockedService.Setup(s => s.Unsubscribe(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(isSubscribed);

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedFactory = new Mock<IViewModelFactory>();

            var controller = new SubscriptionController(mockedService.Object, mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.Unsubscribe(logId);

            // Assert
            mockedFactory.Verify(f => f.CreateSubscribeViewModel(!isSubscribed, logId), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnsubscribe_ShouldRenderCorrectPartialViewWithModel(int logId, string userId)
        {
            // Arrange
            var mockedService = new Mock<ISubscriptionService>();
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var model = new SubscribeViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateSubscribeViewModel(It.IsAny<bool>(), It.IsAny<int>()))
                .Returns(model);

            var controller = new SubscriptionController(mockedService.Object, mockedProvider.Object, mockedFactory.Object);

            // Act
            controller
                .WithCallTo(c => c.Unsubscribe(logId))
                .ShouldRenderPartialView("_SubscriptionPartial")
                .WithModel(model);
        }
    }
}
