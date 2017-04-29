using NUnit.Framework;

namespace Logs.Models.Tests.VoteTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(1)]
        [TestCase(423)]
        [TestCase(123)]
        public void TestLogVoteId_ShouldInitializeCorrectly(int voteId)
        {
            // Arrange
            var vote = new Vote();

            // Act
            vote.LogVoteId = voteId;

            // Assert
            Assert.AreEqual(voteId, vote.LogVoteId);
        }

        [Test]
        public void TestLog_ShouldSetCorrectly()
        {
            // Arrange
            var log = new TrainingLog();
            var vote = new Vote();

            // Act
            vote.TrainingLog = log;

            // Assert
            Assert.AreSame(log, vote.TrainingLog);
        }

        [Test]
        public void TestUser_ShouldSetCorrectly()
        {
            // Arrange
            var user = new User();
            var vote = new Vote();

            // Act
            vote.User = user;

            // Assert
            Assert.AreSame(user, vote.User);
        }
    }
}
