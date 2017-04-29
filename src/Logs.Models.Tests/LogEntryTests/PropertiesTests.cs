using NUnit.Framework;

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
    }
}
