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
    public class AddEntryToLogTests
    {
        [TestCase(1)]
        public void TestAddEntryToLog_ShouldCallRepositoryGetByIdCorrectly(int logId)
        {
            // Arrange
            var entry = new LogEntry();

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
            service.AddEntryToLog(logId, entry);

            // Assert
            mockedLogRepository.Verify(r => r.GetById(logId), Times.Once);
        }

        [TestCase(1)]
        public void TestAddEntryToLog_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(int logId)
        {
            // Arrange
            var entry = new LogEntry();

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
            service.AddEntryToLog(logId, entry);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase(1, "pesho")]
        public void TestAddEntryToLog_RepositoryReturnsLog_ShouldAddEntryToLogEntries(int logId, string username)
        {
            // Arrange
            var user = new User { Name = username };
            var entry = new LogEntry();
            var log = new TrainingLog { User = user };

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
            service.AddEntryToLog(logId, entry);

            // Assert
            CollectionAssert.Contains(log.Entries, entry);
        }

        [TestCase(1, "pesho")]
        public void TestAddEntryToLog_RepositoryReturnsLog_ShouldSetLogLastEntryDate(int logId, string username)
        {
            // Arrange
            var user = new User { Name = username };
            var entry = new LogEntry { EntryDate = new DateTime() };
            var log = new TrainingLog { User = user };

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
            service.AddEntryToLog(logId, entry);

            // Assert
            Assert.AreEqual(entry.EntryDate, log.LastEntryDate);
        }

        [TestCase(1, "pesho")]
        public void TestAddEntryToLog_RepositoryReturnsLog_ShouldSetLogLastActivityUser(int logId, string username)
        {
            // Arrange
            var user = new User { Name = username };
            var entry = new LogEntry { EntryDate = new DateTime() };
            var log = new TrainingLog { User = user };

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
            service.AddEntryToLog(logId, entry);

            // Assert
            Assert.AreEqual(username, log.LastActivityUser);
        }

        [TestCase(1, "pesho")]
        public void TestAddEntryToLog_RepositoryReturnsLog_ShouldCallUnitOfWorkCommit(int logId, string username)
        {
            // Arrange
            var user = new User { Name = username };
            var entry = new LogEntry { EntryDate = new DateTime() };
            var log = new TrainingLog { User = user };

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
            service.AddEntryToLog(logId, entry);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }
    }
}
