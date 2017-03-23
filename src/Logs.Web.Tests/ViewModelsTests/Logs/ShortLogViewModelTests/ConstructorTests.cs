using System;
using System.Collections.Generic;
using Logs.Models;
using Logs.Web.Models.Logs;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Logs.ShortLogViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase("name", 1, "username", "user")]
        public void TestConstructor_ShouldInitializeCorrectly(string name, int logId, string username,
            string lastActivityUser)
        {
            // Arrange
            var log = new TrainingLog
            {
                Name = name,
                LogId = logId,
                Owner = username,
                LastActivityUser = lastActivityUser,
                DateCreated = new DateTime(),
                Entries = new List<LogEntry>(),
                LastEntryDate = new DateTime(),
                Votes = new List<Vote>()
            };

            // Act
            var model = new ShortLogViewModel(log);

            // Assert
            Assert.IsNotNull(model);
        }

        [TestCase("name", 1, "username", "user")]
        public void TestConstructor_ShouldSetDateCreatedCorrectly(string name, int logId, string username,
            string lastActivityUser)
        {
            // Arrange
            var log = new TrainingLog
            {
                Name = name,
                LogId = logId,
                Owner = username,
                LastActivityUser = lastActivityUser,
                DateCreated = new DateTime(),
                Entries = new List<LogEntry>(),
                LastEntryDate = new DateTime(),
                Votes = new List<Vote>()
            };

            // Act
            var model = new ShortLogViewModel(log);

            // Assert
            Assert.AreEqual(log.DateCreated, model.DateCreated);
        }

        [TestCase("name", 1, "username", "user")]
        public void TestConstructor_ShouldSetEntriesCorrectly(string name, int logId, string username,
            string lastActivityUser)
        {
            // Arrange
            var log = new TrainingLog
            {
                Name = name,
                LogId = logId,
                Owner = username,
                LastActivityUser = lastActivityUser,
                DateCreated = new DateTime(),
                Entries = new List<LogEntry> { new LogEntry() },
                LastEntryDate = new DateTime(),
                Votes = new List<Vote>()
            };

            // Act
            var model = new ShortLogViewModel(log);

            // Assert
            Assert.AreEqual(log.Entries.Count, model.Entries);
        }

        [TestCase("name", 1, "username", "user")]
        public void TestConstructor_ShouldSetLastActivityCorrectly(string name, int logId, string username,
            string lastActivityUser)
        {
            // Arrange
            var log = new TrainingLog
            {
                Name = name,
                LogId = logId,
                Owner = username,
                LastActivityUser = lastActivityUser,
                DateCreated = new DateTime(),
                Entries = new List<LogEntry>(),
                LastEntryDate = new DateTime(),
                Votes = new List<Vote>()
            };

            // Act
            var model = new ShortLogViewModel(log);

            // Assert
            Assert.AreEqual(log.LastEntryDate, model.LastActivity);
        }

        [TestCase("name", 1, "username", "user")]
        public void TestConstructor_ShouldSetNameCorrectly(string name, int logId, string username,
            string lastActivityUser)
        {
            // Arrange
            var log = new TrainingLog
            {
                Name = name,
                LogId = logId,
                Owner = username,
                LastActivityUser = lastActivityUser,
                DateCreated = new DateTime(),
                Entries = new List<LogEntry>(),
                LastEntryDate = new DateTime(),
                Votes = new List<Vote>()
            };

            // Act
            var model = new ShortLogViewModel(log);

            // Assert
            Assert.AreEqual(log.Name, model.Name);
        }

        [TestCase("name", 1, "username", "user")]
        public void TestConstructor_ShouldSetLastActivityUserCorrectly(string name, int logId, string username,
            string lastActivityUser)
        {
            // Arrange
            var log = new TrainingLog
            {
                Name = name,
                LogId = logId,
                Owner = username,
                LastActivityUser = lastActivityUser,
                DateCreated = new DateTime(),
                Entries = new List<LogEntry>(),
                LastEntryDate = new DateTime(),
                Votes = new List<Vote>()
            };

            // Act
            var model = new ShortLogViewModel(log);

            // Assert
            Assert.AreEqual(log.LastActivityUser, model.LastActivityUser);
        }

        [TestCase("name", 1, "username", "user")]
        public void TestConstructor_ShouldSetLogIdCorrectly(string name, int logId, string username,
            string lastActivityUser)
        {
            // Arrange
            var log = new TrainingLog
            {
                Name = name,
                LogId = logId,
                Owner = username,
                LastActivityUser = lastActivityUser,
                DateCreated = new DateTime(),
                Entries = new List<LogEntry>(),
                LastEntryDate = new DateTime(),
                Votes = new List<Vote>()
            };

            // Act
            var model = new ShortLogViewModel(log);

            // Assert
            Assert.AreEqual(log.LogId, model.LogId);
        }

        [TestCase("name", 1, "username", "user")]
        public void TestConstructor_ShouldSetVotesCorrectly(string name, int logId, string username,
            string lastActivityUser)
        {
            // Arrange
            var log = new TrainingLog
            {
                Name = name,
                LogId = logId,
                Owner = username,
                LastActivityUser = lastActivityUser,
                DateCreated = new DateTime(),
                Entries = new List<LogEntry>(),
                LastEntryDate = new DateTime(),
                Votes = new List<Vote> { new Vote() }
            };

            // Act
            var model = new ShortLogViewModel(log);

            // Assert
            Assert.AreEqual(log.Votes.Count, model.Votes);
        }

        [TestCase("name", 1, "username", "user")]
        public void TestConstructor_ShouldSetUsernameCorrectly(string name, int logId, string username,
            string lastActivityUser)
        {
            // Arrange
            var log = new TrainingLog
            {
                Name = name,
                LogId = logId,
                Owner = username,
                LastActivityUser = lastActivityUser,
                DateCreated = new DateTime(),
                Entries = new List<LogEntry>(),
                LastEntryDate = new DateTime(),
                Votes = new List<Vote>()
            };

            // Act
            var model = new ShortLogViewModel(log);

            // Assert
            Assert.AreEqual(log.Owner, model.Username);
        }
    }
}
