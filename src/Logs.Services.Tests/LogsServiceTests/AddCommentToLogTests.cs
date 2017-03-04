using System;
using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.LogsServiceTests
{
    [TestFixture]
    public class AddCommentToLogTests
    {
        [TestCase(1)]
        public void TestAddCommentToLog_ShouldCallRepositoryGetByIdCorrectly(int logId)
        {
            // Arrange
            var entry = new Comment();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.AddCommentToLog(logId, entry);

            // Assert
            mockedLogRepository.Verify(r => r.GetById(logId), Times.Once);
        }

        [TestCase(1)]
        public void TestAddCommentToLog_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(int logId)
        {
            // Arrange
            var entry = new Comment();

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.AddCommentToLog(logId, entry);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase(1, "pesho")]
        public void TestAddCommentToLog_RepositoryReturnsLog_ShouldAddCommentToLogEntries(int logId, string username)
        {
            // Arrange
            var user = new User { Name = username };

            var entry = new Comment { User = user };

            var lastEntry = new LogEntry();

            var log = new TrainingLog { User = user };
            log.LastEntry = lastEntry;

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetById(It.IsAny<object>()))
                .Returns(log);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.AddCommentToLog(logId, entry);

            // Assert
            CollectionAssert.Contains(log.LastEntry.Comments, entry);
        }

        [TestCase(1, "pesho")]
        public void TestAddCommentToLog_RepositoryReturnsLog_ShouldSetLogLastEntryDate(int logId, string username)
        {
            // Arrange
            var user = new User { Name = username };

            var entry = new Comment { User = user, Date = new DateTime() };

            var lastEntry = new LogEntry();

            var log = new TrainingLog { User = user };
            log.LastEntry = lastEntry;

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetById(It.IsAny<object>()))
                .Returns(log);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.AddCommentToLog(logId, entry);

            // Assert
            Assert.AreEqual(entry.Date, log.LastEntryDate);
        }

        [TestCase(1, "pesho")]
        public void TestAddCommentToLog_RepositoryReturnsLog_ShouldSetLogLastActivityUser(int logId, string username)
        {
            // Arrange
            var user = new User { Name = username };

            var entry = new Comment { User = user, Date = new DateTime() };

            var lastEntry = new LogEntry();

            var log = new TrainingLog { User = user };
            log.LastEntry = lastEntry;

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetById(It.IsAny<object>()))
                .Returns(log);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.AddCommentToLog(logId, entry);

            // Assert
            Assert.AreEqual(username, log.LastActivityUser);
        }

        [TestCase(1, "pesho")]
        public void TestAddCommentToLog_RepositoryReturnsLog_ShouldCallUnitOfWorkCommit(int logId, string username)
        {
            // Arrange
            var user = new User { Name = username };

            var entry = new Comment { User = user, Date = new DateTime() };

            var lastEntry = new LogEntry();

            var log = new TrainingLog { User = user };
            log.LastEntry = lastEntry;

            var mockedLogRepository = new Mock<IRepository<TrainingLog>>();
            mockedLogRepository.Setup(r => r.GetById(It.IsAny<object>()))
                .Returns(log);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedLogFactory = new Mock<ITrainingLogFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var service = new LogsService(mockedLogRepository.Object,
                mockedUnitOfWork.Object,
                mockedLogFactory.Object,
                mockedUserService.Object,
                mockedDateTimeProvider.Object);

            // Act
            service.AddCommentToLog(logId, entry);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }
    }
}
