using NUnit.Framework;
using System.Collections.Generic;

namespace Logs.Models.Tests.LogEntryTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(1)]
        [TestCase(12)]
        [TestCase(431)]
        [TestCase(21311)]
        [TestCase(1209731)]
        [TestCase(5665)]
        [TestCase(123)]
        [TestCase(11)]
        public void TestLogEntryId_ShouldInitializeCorrectly(int logEntryId)
        {
            // Arrange
            var logEntry = new LogEntry();

            // Act
            logEntry.LogEntryId = logEntryId;

            // Assert
            Assert.AreEqual(logEntryId, logEntry.LogEntryId);
        }

        [Test]
        public void TestLog_ShouldInitializeCorrectly()
        {
            // Arrange
            var log = new TrainingLog();
            var logEntry = new LogEntry();

            // Act
            logEntry.TrainingLog = log;

            // Assert
            Assert.AreSame(log, logEntry.TrainingLog);
        }

        [Test]
        public void TestUser_ShouldInitializeCorrectly()
        {
            // Arrange
            var user = new User();
            var logEntry = new LogEntry();

            // Act
            logEntry.User = user;

            // Assert
            Assert.AreSame(user, logEntry.User);
        }

        [Test]
        public void TestTrainingLogs_ShouldInitializeCorrectly()
        {
            // Arrange
            var logs = new List<TrainingLog>();
            var logEntry = new LogEntry();

            // Act
            logEntry.TrainingLogs = logs;

            // Assert
            CollectionAssert.AreEqual(logs, logEntry.TrainingLogs);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestUserId_ShouldInitializeCorrectly(string userId)
        {
            // Arrange
            var logEntry = new LogEntry();

            // Act
            logEntry.UserId = userId;

            // Assert
            Assert.AreEqual(userId, logEntry.UserId);
        }
    }
}
