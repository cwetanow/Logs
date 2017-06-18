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
    public class UnsubscribeTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnsubscribe_NoSubscription_ShouldNotCallRepositoryDelete(int logId, string userId)
        {
            // Arrange
            var subscription = new Subscription();

            var subscriptions = new List<Subscription> { subscription }
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            // Act
            service.Unsubscribe(logId, userId);

            // Assert
            mockedRepository.Verify(r => r.Delete(It.IsAny<Subscription>()), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnsubscribe_NoSubscription_ShouldReturnFalse(int logId, string userId)
        {
            // Arrange
            var subscription = new Subscription();

            var subscriptions = new List<Subscription> { subscription }
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            // Act
            var result = service.Unsubscribe(logId, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnsubscribe_UserIdIsNull_ShouldNotCallRepositoryDelete(int logId, string userId)
        {
            // Arrange
            var subscription = new Subscription { TrainingLogId = logId };

            var subscriptions = new List<Subscription> { subscription }
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            userId = null;

            // Act
            service.Unsubscribe(logId, userId);

            // Assert
            mockedRepository.Verify(r => r.Delete(It.IsAny<Subscription>()), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnsubscribe_UserIdIsNull_ShouldReturnFalse(int logId, string userId)
        {
            // Arrange
            var subscription = new Subscription { TrainingLogId = logId };

            var subscriptions = new List<Subscription> { subscription }
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            userId = null;

            // Act
            var result = service.Unsubscribe(logId, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnsubscribe_SubscriptionFound_ShouldCallRepositoryDelete(int logId, string userId)
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
            var result = service.Unsubscribe(logId, userId);

            // Assert
            mockedRepository.Verify(r => r.Delete(subscription), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnsubscribe_SubscriptionFound_ShouldCallUnitOfWorkCommit(int logId, string userId)
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
            var result = service.Unsubscribe(logId, userId);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUnsubscribe_SubscriptionFound_ShouldReturnTrue(int logId, string userId)
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
            var result = service.Unsubscribe(logId, userId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
