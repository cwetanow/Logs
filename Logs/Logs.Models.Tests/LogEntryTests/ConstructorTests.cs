using System;
using NUnit.Framework;

namespace Logs.Models.Tests.LogEntryTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase("content", 1)]
        public void TestConstructor_ShouldInitializeCorrectly(string content, int logId)
        {
            // Arrange, Act
            var entry = new LogEntry(content, new DateTime(), logId);

            // Act
            Assert.IsNotNull(entry);
        }

        [TestCase("content", 1)]
        public void TestConstructor_ShouldSetContentCorrectly(string content, int logId)
        {
            // Arrange
            var date = new DateTime();

            // Act
            var entry = new LogEntry(content, date, logId);

            // Act
            Assert.AreEqual(content, entry.Content);
        }

        [TestCase("content", 1)]
        public void TestConstructor_ShouldSetEntryDateCorrectly(string content, int logId)
        {
            // Arrange
            var date = new DateTime();

            // Act
            var entry = new LogEntry(content, date, logId);

            // Act
            Assert.AreEqual(date, entry.EntryDate);
        }

        [TestCase("content", 1)]
        public void TestConstructor_ShouldSetLogIdCorrectly(string content, int logId)
        {
            // Arrange
            var date = new DateTime();

            // Act
            var entry = new LogEntry(content, date, logId);

            // Act
            Assert.AreEqual(logId, entry.LogId);
        }
    }
}
