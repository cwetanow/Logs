﻿using System;
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
            var mockedRepository = new Mock<IRepository<LogEntry>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.AddEntryToLog(content, logId, null);

            // Assert
            mockedDateTimeProvider.Verify(p => p.GetCurrentTime(), Times.Once);
        }

        [TestCase("content", 1)]
        [TestCase("other content", 2)]
        public void TestAddEntryToLog_ShouldCallFactoryCreateLogEntry(string content, int logId)
        {
            // Arrange
            var mockedLogService = new Mock<ILogService>();

            var date = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrentTime())
                .Returns(date);

            var mockedFactory = new Mock<ILogEntryFactory>();
            var mockedRepository = new Mock<IRepository<LogEntry>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.AddEntryToLog(content, logId, null);

            // Assert
            mockedFactory.Verify(f => f.CreateLogEntry(content, date, logId), Times.Once);
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
            mockedFactory.Setup(f => f.CreateLogEntry(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<int>()))
                .Returns(entry);

            var mockedRepository = new Mock<IRepository<LogEntry>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new EntryService(mockedLogService.Object,
                mockedDateTimeProvider.Object,
                mockedFactory.Object,
                mockedRepository.Object,
                mockedUnitOfWork.Object);

            // Act
            service.AddEntryToLog(content, logId, null);


            // Assert
            mockedLogService.Verify(s => s.AddEntryToLog(logId, entry, null), Times.Once);
        }
    }
}
