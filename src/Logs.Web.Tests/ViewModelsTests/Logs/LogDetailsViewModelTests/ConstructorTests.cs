using System;
using System.Collections.Generic;
using Logs.Models;
using Logs.Web.Models.Logs;
using NUnit.Framework;
using PagedList;

namespace Logs.Web.Tests.ViewModelsTests.Logs.LogDetailsViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase("description")]
        [TestCase("me be very interesting")]
        public void TestConstructor_ShouldSetDescriptionCorrectly(string description)
        {
            // Arrange
            var trainingLog = new TrainingLog { Description = description };

            // Act
            var model = new LogDetailsViewModel(trainingLog, true, true, true, null);

            // Assert
            Assert.AreEqual(description, model.Description);
        }

        [TestCase("my name")]
        [TestCase("logs")]
        [TestCase("test")]
        public void TestConstructor_ShouldSetNameCorrectly(string name)
        {
            // Arrange
            var trainingLog = new TrainingLog { Name = name };

            // Act
            var model = new LogDetailsViewModel(trainingLog, true, true, true, null);

            // Assert
            Assert.AreEqual(name, model.Name);
        }

        [Test]
        public void TestConstructor_ShouldSetDateCreatedCorrectly()
        {
            // Arrange
            var date = new DateTime();
            var trainingLog = new TrainingLog { DateCreated = date };

            // Act
            var model = new LogDetailsViewModel(trainingLog, true, true, true, null);

            // Assert
            Assert.AreEqual(date, model.DateCreated);
        }

        [TestCase("pesho")]
        [TestCase("john skeet")]
        [TestCase("stamat")]
        public void TestConstructor_ShouldSetUserCorrectly(string owner)
        {
            // Arrange
            var trainingLog = new TrainingLog { Owner = owner };

            // Act
            var model = new LogDetailsViewModel(trainingLog, true, true, true, null);

            // Assert
            Assert.AreEqual(owner, model.User);
        }

        [Test]
        public void TestConstructor_ShouldSetVotesCountCorrectly()
        {
            // Arrange
            var votes = new List<Vote> { new Vote(), new Vote() };
            var trainingLog = new TrainingLog { Votes = votes };

            // Act
            var model = new LogDetailsViewModel(trainingLog, true, true, false, null);

            // Assert
            Assert.AreEqual(votes.Count, model.VotesCount);
        }

        [TestCase(1)]
        [TestCase(423)]
        [TestCase(519)]
        public void TestConstructor_ShouldSetLogIdCorrectly(int logId)
        {
            // Arrange
            var trainingLog = new TrainingLog { LogId = logId };

            // Act
            var model = new LogDetailsViewModel(trainingLog, true, true, false, null);

            // Assert
            Assert.AreEqual(logId, model.LogId);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void TestConstructor_ShouldSetIsAuthenticatedCorrectly(bool isAuthenticated)
        {
            // Arrange
            var trainingLog = new TrainingLog();

            // Act
            // Act
            var model = new LogDetailsViewModel(trainingLog, isAuthenticated, true, false, null);

            // Assert
            Assert.AreEqual(isAuthenticated, model.IsAuthenticated);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestConstructor_ShouldSetCanEditCorrectly(bool canEdit)
        {
            // Arrange
            var trainingLog = new TrainingLog();

            // Act
            // Act
            var model = new LogDetailsViewModel(trainingLog, true, canEdit, false, null);

            // Assert
            Assert.AreEqual(canEdit, model.CanEdit);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestConstructor_ShouldSetCanVoteCorrectly(bool canVote)
        {
            // Arrange
            var trainingLog = new TrainingLog();

            // Act
            var model = new LogDetailsViewModel(trainingLog, true, false, canVote, null);

            // Assert
            Assert.AreEqual(canVote, model.CanVote);
        }

        [Test]
        public void TestConstructor_ShouldSetEntriesCorrectly()
        {
            // Arrange
            var trainingLog = new TrainingLog();
            var entries = new List<LogEntryViewModel>().ToPagedList(1, 1);

            // Act
            var model = new LogDetailsViewModel(trainingLog, true, true, true, entries);

            // Assert
            CollectionAssert.AreEqual(entries, model.Entries);
        }

        [Test]
        public void TestConstructor_LogUserIsNull_ShouldSetProfileImageUrlNull()
        {
            // Arrange
            var trainingLog = new TrainingLog();

            // Act
            var model = new LogDetailsViewModel(trainingLog, true, true, true, null);

            // Assert
            Assert.IsNull(model.ProfileImageUrl);
        }

        [TestCase("http://pnge.org/hd-wallpapers/image-2359")]
        [TestCase("https://camo.mybb.com/e01de90be6012adc1b1701dba899491a9348ae79/687474703a2f2f7777772e6a71756572797363726970742e6e65742f696d616765732f53696d706c6573742d526573706f6e736976652d6a51756572792d496d6167652d4c69676874626f782d506c7567696e2d73696d706c652d6c69676874626f782e6a7067")]
        [TestCase("https://www.w3schools.com/css/trolltunga.jpg")]
        public void TestConstructor_LogUserIsNotNull_ShouldSetProfileImageUrlCorrectly(string imageUrl)
        {
            // Arrange
            var user = new User { ProfileImageUrl = imageUrl };
            var trainingLog = new TrainingLog { User = user };

            // Act
            var model = new LogDetailsViewModel(trainingLog, true, true, true, null);

            // Assert
            Assert.AreEqual(imageUrl, model.ProfileImageUrl);
        }
    }
}
