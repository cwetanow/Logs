using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.EntryServiceTests
{
    [TestFixture]
    public class EditEntryTests
    {
        [TestCase(1, "description")]
        [TestCase(1423, "another description")]
        public void TestEditEntry_ShouldCallRepositoryGetById(int entryId, string newContent)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedRepository = new Mock<IRepository<LogEntry>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.EditEntry(entryId, newContent);

            // Assert
            mockedRepository.Verify(r => r.GetById(entryId), Times.Once);
        }

        [TestCase(1, "description")]
        [TestCase(1423, "another description")]
        public void TestEditEntry_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(int entryId, string newContent)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedRepository = new Mock<IRepository<LogEntry>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.EditEntry(entryId, newContent);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase(1, "description")]
        [TestCase(1423, "another description")]
        public void TestEditEntry_RepositoryReturnsEntry_ShouldSetEntryContent(int entryId, string newContent)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();

            var entry = new LogEntry();

            var mockedRepository = new Mock<IRepository<LogEntry>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(entry);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.EditEntry(entryId, newContent);

            // Assert
            Assert.AreEqual(newContent, entry.Content);
        }

        [TestCase(1, "description")]
        [TestCase(1423, "another description")]
        public void TestEditEntry_RepositoryReturnsEntry_ShouldCallRepositoryUpdate(int entryId, string newContent)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();

            var entry = new LogEntry();

            var mockedRepository = new Mock<IRepository<LogEntry>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(entry);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.EditEntry(entryId, newContent);

            // Assert
            mockedRepository.Verify(r => r.Update(entry), Times.Once);
        }

        [TestCase(1, "description")]
        [TestCase(1423, "another description")]
        public void TestEditEntry_RepositoryReturnsEntry_ShouldCallUnitOfWorkCommit(int entryId, string newContent)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();

            var entry = new LogEntry();

            var mockedRepository = new Mock<IRepository<LogEntry>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(entry);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.EditEntry(entryId, newContent);

            // Assert
            mockedUnitOfWork.Verify(r => r.Commit(), Times.Once);
        }
    }
}
