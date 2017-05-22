using Logs.Web.Models.Nutrition;
using NUnit.Framework;
using System;

namespace Logs.Web.Tests.ViewModelsTests.Measurement.MeasurementViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassMeasurementNull_ShouldSetDateCorrectly()
        {
            // Arrange
            var date = new DateTime(1, 2, 3);

            // Act
            var model = new MeasurementViewModel(null, date);

            // Assert
            Assert.AreEqual(date, model.Date);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetIdCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, date);

            // Assert
            Assert.AreEqual(id, model.Id);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetHeightCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, date);

            // Assert
            Assert.AreEqual(height, model.Height);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetWeightKgCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var Measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            Measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(Measurement, date);

            // Assert
            Assert.AreEqual(weightKg, model.WeightKg);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetBodyFatPercentCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, date);

            // Assert
            Assert.AreEqual(bodyFatPercent, model.BodyFatPercent);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetChestCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var Measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            Measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(Measurement, date);

            // Assert
            Assert.AreEqual(chest, model.Chest);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetShouldersCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, date);

            // Assert
            Assert.AreEqual(shoulders, model.Shoulders);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetForearmCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var Measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            Measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(Measurement, date);

            // Assert
            Assert.AreEqual(forearm, model.Forearm);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetArmCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, date);

            // Assert
            Assert.AreEqual(arm, model.Arm);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetWaistCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, date);

            // Assert
            Assert.AreEqual(waist, model.Waist);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetHipsCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var Measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            Measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(Measurement, date);

            // Assert
            Assert.AreEqual(hips, model.Hips);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetThighsCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, date);

            // Assert
            Assert.AreEqual(thighs, model.Thighs);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetCalvesCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, date);

            // Assert
            Assert.AreEqual(calves, model.Calves);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetNeckCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var Measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            Measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(Measurement, date);

            // Assert
            Assert.AreEqual(neck, model.Neck);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetWristCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, date);

            // Assert
            Assert.AreEqual(wrist, model.Wrist);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetAnkleCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, date);

            // Assert
            Assert.AreEqual(ankle, model.Ankle);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29)]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22)]
        public void TestConstructor_PassMeasurement_ShouldSetDateCorrectly(int id,
                  int height,
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
                  int ankle)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);
            var measurement = new global::Logs.Models.Measurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, null, date);
            measurement.MeasurementsId = id;

            // Act
            var model = new MeasurementViewModel(measurement, new DateTime());

            // Assert
            Assert.AreEqual(date, model.Date);
        }
    }
}
