using Logs.Web.Models.Subscription;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Subscription.SubscribeViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase(true, 1)]
        [TestCase(true, 42)]
        [TestCase(false, 1)]
        [TestCase(false, 42)]
        public void TestConstructor_ShouldSetIsSubscribedCorrectly(bool isSubscribed, int logId)
        {
            // Arrange, Act
            var model = new SubscribeViewModel(isSubscribed, logId);

            // Assert
            Assert.AreEqual(isSubscribed, model.IsSubscribed);
        }

        [TestCase(true, 1)]
        [TestCase(true, 42)]
        [TestCase(false, 1)]
        [TestCase(false, 42)]
        public void TestConstructor_ShouldSetLogIdCorrectly(bool isSubscribed, int logId)
        {
            // Arrange, Act
            var model = new SubscribeViewModel(isSubscribed, logId);

            // Assert
            Assert.AreEqual(logId, model.LogId);
        }
    }
}
