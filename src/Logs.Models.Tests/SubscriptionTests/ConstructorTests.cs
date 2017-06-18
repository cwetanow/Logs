using NUnit.Framework;

namespace Logs.Models.Tests.SubscriptionTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetTrainingLogIdCorrectly(int logId, string userId)
        {
            // Arrange, Act
            var subscription = new Subscription(logId, userId);

            // Assert
            Assert.AreEqual(logId, subscription.TrainingLogId);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(423, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetUserIdCorrectly(int logId, string userId)
        {
            // Arrange, Act
            var subscription = new Subscription(logId, userId);

            // Assert
            Assert.AreEqual(userId, subscription.UserId);
        }
    }
}
