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
    public class EditCommentTests
    {
        [TestCase(1, "content")]
        [TestCase(1423, "another content")]
        public void TestEditComment_ShouldCallRepositoryGetById(int commentId, string newContent)
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
            service.EditComment(commentId, newContent);

            // Assert
            mockedRepository.Verify(r => r.GetById(commentId), Times.Once);
        }

        [TestCase(1, "content")]
        [TestCase(1423, "another content")]
        public void TestEditComment_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(int commentId, string newContent)
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
            service.EditComment(commentId, newContent);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase(1, "content")]
        [TestCase(1423, "another content")]
        public void TestEditComment_RepositoryReturnsNull_ShouldReturnNull(int commentId, string newContent)
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
            var result = service.EditComment(commentId, newContent);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase(1, "content")]
        [TestCase(1423, "another content")]
        public void TestEditComment_RepositoryReturnsComment_ShouldSetContentCorrectly(int commentId, string newContent)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var comment = new Comment();

            var mockedRepository = new Mock<IRepository<Comment>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(comment);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.EditComment(commentId, newContent);

            // Assert
            Assert.AreEqual(newContent, comment.Content);
        }

        [TestCase(1, "content")]
        [TestCase(1423, "another content")]
        public void TestEditComment_ShouldCallRepositoryUpdate(int commentId, string newContent)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var comment = new Comment();

            var mockedRepository = new Mock<IRepository<Comment>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(comment);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.EditComment(commentId, newContent);

            // Assert
            mockedRepository.Verify(r => r.Update(comment), Times.Once);
        }

        [TestCase(1, "content")]
        [TestCase(1423, "another content")]
        public void TestEditComment_ShouldCallUnitOfWorkCommit(int commentId, string newContent)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var comment = new Comment();

            var mockedRepository = new Mock<IRepository<Comment>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(comment);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.EditComment(commentId, newContent);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(1, "content")]
        [TestCase(1423, "another content")]
        public void TestEditComment_ShouldReturnCorrectly(int commentId, string newContent)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var comment = new Comment();

            var mockedRepository = new Mock<IRepository<Comment>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(comment);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new CommentService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            var result = service.EditComment(commentId, newContent);

            // Assert
            Assert.AreSame(comment, result);
        }
    }
}
