using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.VoteServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            // Act
            var service = new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object,
               mockedVoteFactory.Object);

            // Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldNotThrow()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            // Act, Assert
            Assert.DoesNotThrow(() => new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object,
               mockedVoteFactory.Object));
        }

        [Test]
        public void TestConstructor_PassRepositoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            // Act, Asesrt
            Assert.Throws<ArgumentNullException>(() => new VoteService(null, mockedUnitOfWork.Object, mockedLogService.Object,
                mockedVoteFactory.Object));
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedLogService = new Mock<ILogService>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            // Act, Asesrt
            Assert.Throws<ArgumentNullException>(() => new VoteService(mockedRepository.Object, null, mockedLogService.Object,
                mockedVoteFactory.Object));
        }

        [Test]
        public void TestConstructor_PassLogServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedVoteFactory = new Mock<IVoteFactory>();

            // Act, Asesrt
            Assert.Throws<ArgumentNullException>(() => new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, null,
                mockedVoteFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoruNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Vote>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogService = new Mock<ILogService>();

            // Act, Asesrt
            Assert.Throws<ArgumentNullException>(() => new VoteService(mockedRepository.Object, mockedUnitOfWork.Object, mockedLogService.Object,
                null));
        }
    }
}
