using NUnit.Framework;

namespace Logs.Models.Tests.MeasurementTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(1)]
        [TestCase(999)]
        [TestCase(326)]
        [TestCase(1257)]
        [TestCase(73)]
        [TestCase(14)]
        public void TestMeasurementsId_ShouldInitializeCorrectly(int measurementId)
        {
            // Arrange
            var measurement = new Measurement();

            // Act
            measurement.MeasurementsId = measurementId;

            // Assert
            Assert.AreEqual(measurementId, measurement.MeasurementsId);
        }

        [Test]
        public void TestUser_ShouldInitializeCorrectly()
        {
            // Arrange
            var measurement = new Measurement();
            var user = new User();

            // Act
            measurement.User = user;

            // Assert
            Assert.AreSame(user, measurement.User);
        }
    }
}
