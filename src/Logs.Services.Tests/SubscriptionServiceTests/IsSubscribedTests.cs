using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Logs.Services.Tests.SubscriptionServiceTests
{
    [TestFixture]
    public class IsSubscribedTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestIsSubscribed_NoSubscription_ShouldReturnFalse(int logId, string userId)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Subscription>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            // Act
            var result = service.IsSubscribed(logId, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestIsSubscribed_FoundSubscription_ShouldReturnTrue(int logId, string userId)
        {
            // Arrange
            var subscription = new Subscription { TrainingLogId = logId, UserId = userId };

            var subscriptions = new List<Subscription> { subscription }
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            // Act
            var result = service.IsSubscribed(logId, userId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
