using Logs.Web.Models.Nutrition;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logs.Web.Tests.ViewModelsTests.Nutrition.MeasurementStatsViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange, Act
            var model = new MeasurementStatsViewModel();

            // Assert
            Assert.IsNotNull(model);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Height);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Height);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetDatesCorrectly(int height,
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Date.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture));

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Dates);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Ankle);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Ankle);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetWeightKgCorrectly(int height,
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.WeightKg);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.WeightKg);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Wrist);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Wrist);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Neck);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Neck);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Calves);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Calves);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Thighs);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Thighs);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Hips);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Hips);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Waist);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Waist);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Arm);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Arm);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Forearm);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Forearm);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Shoulders);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Shoulders);
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.Chest);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.Chest);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetBodyFatPercentCorrectly(int height,
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => m.BodyFatPercent);

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AreEqual(expected, model.BodyFatPercent);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestConstructor_ShouldSetListModelCorrectly(int height,
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
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            var list = new List<global::Logs.Models.Measurement> { measurement };

            var expected = list.Select(m => new DateIdViewModel(m.MeasurementsId,
                m.Date.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)))
                .Reverse();

            // Act
            var model = new MeasurementStatsViewModel(list);

            // Assert
            CollectionAssert.AllItemsAreNotNull(model.ListModel);
        }
    }
}
