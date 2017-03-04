using System;
using Logs.Factories;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.EntryServiceTests
{
    [TestFixture]
    public class AddEntryToLogTests
    {
        [TestCase("content", 1)]
        [TestCase("other content", 2)]
        public void TestAddEntryToLog_ShouldCallDateTimeProviderGetCurrentTime(string content, int logId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object);

            // Act
            service.AddEntryToLog(content, logId);

            // Assert
            mockedDateTimeProvider.Verify(p => p.GetCurrenTime(), Times.Once);
        }

        [TestCase("content", 1)]
        [TestCase("other content", 2)]
        public void TestAddEntryToLog_ShouldCallFactoryCreateLogEntry(string content, int logId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();

            var date = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrenTime())
                .Returns(date);

            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object);

            // Act
            service.AddEntryToLog(content, logId);

            // Assert
            mockedFactory.Verify(f => f.CreateLogEntry(content, date), Times.Once);
        }

        [TestCase("content", 1)]
        [TestCase("other content", 2)]
        public void TestAddEntryToLog_ShouldCallServiceAddEntryToLog(string content, int logId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var entry = new LogEntry();

            var mockedFactory = new Mock<ILogEntryFactory>();
            mockedFactory.Setup(f => f.CreateLogEntry(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(entry);

            var mockedUserService = new Mock<IUserService>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedUserService.Object,
                mockedCommentFactory.Object);

            // Act
            service.AddEntryToLog(content, logId);

            // Assert
            mockedLogService.Verify(s => s.AddEntryToLog(logId, entry), Times.Once);
        }
    }
}
