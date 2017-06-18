using NUnit.Framework;

namespace Logs.Models.Tests.SubscriptionTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(1)]
        [TestCase(423)]
        [TestCase(123)]
        public void TestSubscriptionId_ShouldInitializeCorrectly(int SubscriptionId)
        {
            // Arrange
            var subscription = new Subscription();

            // Act
            subscription.SubscriptionId = SubscriptionId;

            // Assert
            Assert.AreEqual(SubscriptionId, subscription.SubscriptionId);
        }

        [Test]
        public void TestLog_ShouldSetCorrectly()
        {
            // Arrange
            var log = new TrainingLog();
            var subscription = new Subscription();

            // Act
            subscription.TrainingLog = log;

            // Assert
            Assert.AreSame(log, subscription.TrainingLog);
        }

        [Test]
        public void TestUser_ShouldSetCorrectly()
        {
            // Arrange
            var user = new User();
            var subscription = new Subscription();

            // Act
            subscription.User = user;

            // Assert
            Assert.AreSame(user, subscription.User);
        }
    }
}
