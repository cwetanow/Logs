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
    public class DeleteCommentTests
    {
        [TestCase(1)]
        [TestCase(12)]
        public void TestDeleteComment_ShouldCallRepositoryGetById(int commentId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var mockedRepository = new Mock<IRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.DeleteComment(commentId);

            // Assert
            mockedRepository.Verify(r => r.GetById(commentId), Times.Once);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestDeleteComment_RepositoryReturnsNull_ShouldNotCallRepositoryDelete(int commentId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var mockedRepository = new Mock<IRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.DeleteComment(commentId);

            // Assert
            mockedRepository.Verify(r => r.Delete(It.IsAny<Comment>()), Times.Never);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestDeleteComment_RepositoryReturnsNull_ShouldReturnFalse(int commentId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();
            var mockedRepository = new Mock<IRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            var result = service.DeleteComment(commentId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestDeleteComment_RepositoryReturnsComment_ShouldCallRepositoryDelete(int commentId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var comment = new Comment();

            var mockedRepository = new Mock<IRepository<Comment>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>()))
                .Returns(comment);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.DeleteComment(commentId);

            // Assert
            mockedRepository.Verify(r => r.Delete(comment), Times.Once);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestDeleteComment_RepositoryReturnsComment_ShouldCallUnitOfWorkCommit(int commentId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var comment = new Comment();

            var mockedRepository = new Mock<IRepository<Comment>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>()))
                .Returns(comment);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.DeleteComment(commentId);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestDeleteComment_RepositoryReturnsComment_ShouldReturnTrue(int commentId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var comment = new Comment();

            var mockedRepository = new Mock<IRepository<Comment>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>()))
                .Returns(comment);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            var result = service.DeleteComment(commentId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
