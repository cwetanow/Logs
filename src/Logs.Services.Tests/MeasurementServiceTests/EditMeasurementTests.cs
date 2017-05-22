using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System;

namespace Logs.Services.Tests.MeasurementServiceTests
{
    [TestFixture]
    public class EditMeasurementTests
    {
        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_ShouldCallRepositoryGetById(int id, 
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            mockedMeasurementRepository.Verify(f => f.GetById(id),
                Times.Once);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            mockedUnitOfWork.Verify(f => f.Commit(),
                Times.Never);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_RepositoryReturnsNull_ShouldReturnNull(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_UserIdsAreNotEqual_ShouldNotCallUnitOfWorkCommit(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement();

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                 calves, neck, wrist, ankle);

            // Assert
            mockedUnitOfWork.Verify(f => f.Commit(),
                Times.Never);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_DatessAreNotEqual_ShouldNotCallUnitOfWorkCommit(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                 calves, neck, wrist, ankle);

            // Assert
            mockedUnitOfWork.Verify(f => f.Commit(),
                Times.Never);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetHeightCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(height, Measurement.Height);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetWeightKgCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(weightKg, Measurement.WeightKg);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetBodyFatPercentCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(bodyFatPercent, Measurement.BodyFatPercent);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetChestCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(chest, Measurement.Chest);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetShouldersCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(shoulders, Measurement.Shoulders);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetForearmCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(forearm, Measurement.Forearm);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetArmCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(arm, Measurement.Arm);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetWaistCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(waist, Measurement.Waist);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetHipsCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(hips, Measurement.Hips);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetThighsCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(thighs, Measurement.Thighs);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetCalvesCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(calves, Measurement.Calves);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetNeckCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(neck, Measurement.Neck);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetWristCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(wrist, Measurement.Wrist);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldSetAnkleCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreEqual(ankle, Measurement.Ankle);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldCallRepositoryUpdate(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                 calves, neck, wrist, ankle);

            // Assert
            mockedMeasurementRepository.Verify(r => r.Update(Measurement), Times.Once);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldCallUnitOfWorkCommit(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                   calves, neck, wrist, ankle);

            // Assert
            mockedUnitOfWork.Verify(r => r.Commit(), Times.Once);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestEditMeasurement_MeasurementMatchesDateAndUserId_ShouldReturnCorrectly(int id,
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
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var Measurement = new Measurement { UserId = userId, Date = date };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(Measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle);

            // Assert
            Assert.AreSame(Measurement, result);
        }
    }
}
