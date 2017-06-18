using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System;

namespace Logs.Services.Tests.SubscriptionServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Subscription>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            // Act
            var service = new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, mockedFactory.Object);

            // Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void TestConstructor_PassRepositoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new SubscriptionService(null, mockedUnitOfWork.Object, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Subscription>>();
            var mockedFactory = new Mock<ISubscriptionFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new SubscriptionService(mockedRepository.Object, null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Subscription>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new SubscriptionService(mockedRepository.Object, mockedUnitOfWork.Object, null));
        }
    }
}
