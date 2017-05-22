using NUnit.Framework;
using System;

namespace Logs.Models.Tests.MeasurementTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange, Act
            var measurement = new Measurement();

            // Assert
            Assert.IsNotNull(measurement);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetHeightCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs, 
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(height, measurement.Height);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetWeightCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(weightKg, measurement.WeightKg);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetBodyFatCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(bodyFatPercent, measurement.BodyFatPercent);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetChestCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(chest, measurement.Chest);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetShouldersCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(shoulders, measurement.Shoulders);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetForearmCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(forearm, measurement.Forearm);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetArmCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(arm, measurement.Arm);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetWaistCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(waist, measurement.Waist);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetHipsCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(hips, measurement.Hips);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetThighsCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(thighs, measurement.Thighs);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetCalvesCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(calves, measurement.Calves);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetNeckCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(neck, measurement.Neck);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetWristCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(wrist, measurement.Wrist);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetAnkleCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(ankle, measurement.Ankle);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetUserIdCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(userId, measurement.UserId);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetDateCorrectly(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            // Act
            var measurement = new Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreEqual(date, measurement.Date);
        }
    }
}