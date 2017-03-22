using Logs.Web.Models.Profile;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Profile.NewLogViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase(1)]
        [TestCase(41)]
        [TestCase(11)]
        [TestCase(1231)]
        [TestCase(321)]
        [TestCase(1123)]
        public void TestConstructor_ShouldSetLogIdCorrectly(int logId)
        {
            // Arrange, Act
            var model = new NewLogViewModel(logId);

            // Assert
            Assert.AreEqual(logId, model.LogId);
        }
    }
}
