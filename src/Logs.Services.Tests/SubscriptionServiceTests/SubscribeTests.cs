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
    public class SubscribeTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSubscribe_IsSubscribed_ShouldNotCallFactoryCreate(int logId, string userId)
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
            service.Subscribe(logId, userId);

            // Assert
            mockedFactory.Verify(f => f.CreateSubscription(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSubscribe_IsSubscribed_ShouldReturnFalse(int logId, string userId)
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
            var result = service.Subscribe(logId, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSubscribe_UserIdIsNull_ShouldNotCallFactoryCreate(int logId, string userId)
        {
            // Arrange
            var subscriptions = new List<Subscription>()
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            userId = null;

            // Act
            service.Subscribe(logId, userId);

            // Assert
            mockedFactory.Verify(f => f.CreateSubscription(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSubscribe_UserIdIsNull_ShouldReturnFalse(int logId, string userId)
        {
            // Arrange
            var subscriptions = new List<Subscription>()
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            userId = null;

            // Act
            var result = service.Subscribe(logId, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSubscribe_ParametersCorrect_ShouldCallFactoryCreate(int logId, string userId)
        {
            // Arrange
            var subscriptions = new List<Subscription>()
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            // Act
            var result = service.Subscribe(logId, userId);

            // Assert
            mockedFactory.Verify(f => f.CreateSubscription(logId, userId), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSubscribe_ParametersCorrect_ShouldCallRepositoryAdd(int logId, string userId)
        {
            // Arrange
            var subscriptions = new List<Subscription>()
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var subscription = new Subscription();

            var mockedFactory = new Mock<ISubscriptionFactory>();
            mockedFactory.Setup(f => f.CreateSubscription(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(subscription);

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            // Act
            var result = service.Subscribe(logId, userId);

            // Assert
            mockedRepository.Verify(r => r.Add(subscription), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSubscribe_ParametersCorrect_ShouldCallUnitOfWorkCommit(int logId, string userId)
        {
            // Arrange
            var subscriptions = new List<Subscription>()
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var subscription = new Subscription();

            var mockedFactory = new Mock<ISubscriptionFactory>();
            mockedFactory.Setup(f => f.CreateSubscription(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(subscription);

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            // Act
            var result = service.Subscribe(logId, userId);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSubscribe_ParametersCorrect_ShouldReturnTrue(int logId, string userId)
        {
            // Arrange
            var subscriptions = new List<Subscription>()
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<Subscription>>();
            mockedRepository.Setup(r => r.All).Returns(subscriptions);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var subscription = new Subscription();

            var mockedFactory = new Mock<ISubscriptionFactory>();
            mockedFactory.Setup(f => f.CreateSubscription(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(subscription);

            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            // Act
            var result = service.Subscribe(logId, userId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
