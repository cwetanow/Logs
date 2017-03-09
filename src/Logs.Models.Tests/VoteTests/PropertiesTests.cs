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
    }
}
