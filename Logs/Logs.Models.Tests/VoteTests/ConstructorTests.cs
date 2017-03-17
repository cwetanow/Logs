using NUnit.Framework;

namespace Logs.Models.Tests.VoteTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetLogIdCorrectly(int logId, string userId)
        {
            // Arrange, Act
            var vote = new Vote(logId, userId);

            // Assert
            Assert.AreEqual(logId, vote.LogId);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetUserIdCorrectly(int logId, string userId)
        {
            // Arrange, Act
            var vote = new Vote(logId, userId);

            // Assert
            Assert.AreEqual(userId, vote.UserId);
        }
    }
}
