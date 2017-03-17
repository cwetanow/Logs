using System;
using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.CommentServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var mockedRepository = new Mock<IRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void TestConstructor_PassLogServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var mockedRepository = new Mock<IRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(null,
                   mockedDateTimeProvider.Object,
                   mockedUserService.Object,
                   mockedCommentFactory.Object,
                   mockedRepository.Object,
                   mockedUnitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassDateTimeProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var mockedRepository = new Mock<IRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(mockedLogService.Object,
                   null,
                   mockedUserService.Object,
                   mockedCommentFactory.Object,
                   mockedRepository.Object,
                   mockedUnitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassUserServiceNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var mockedRepository = new Mock<IRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(mockedLogService.Object,
                   mockedDateTimeProvider.Object,
                   null,
                   mockedCommentFactory.Object,
                   mockedRepository.Object,
                   mockedUnitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassCommentFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedRepository = new Mock<IRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(mockedLogService.Object,
                   mockedDateTimeProvider.Object,
                   mockedUserService.Object,
                   null,
                   mockedRepository.Object,
                   mockedUnitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassRepositoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(mockedLogService.Object,
                   mockedDateTimeProvider.Object,
                   mockedUserService.Object,
                   mockedCommentFactory.Object,
                   null,
                   mockedUnitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var mockedRepository = new Mock<IRepository<Comment>>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(mockedLogService.Object,
                   mockedDateTimeProvider.Object,
                   mockedUserService.Object,
                   mockedCommentFactory.Object,
                   mockedRepository.Object,
                   null));
        }
    }
}
