using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logs.Services.Tests.MeasurementServiceTests
{
    [TestFixture]
    public class CreateMeasurementTests
    {
        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateMeasurement_ShouldCallRepositoryAll(int height,
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
            // Arrange
            var date = new DateTime(2, 3, 4);

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.CreateMeasurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            mockedMeasurementRepository.Verify(r => r.All, Times.Once);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateMeasurement_RepositoryReturnsMeasurement_ShouldReturnMeasurement(int height,
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
            // Arrange
            var date = new DateTime(2, 3, 4);

            var measurement = new Measurement { Date = date, UserId = userId };

            var results = new List<Measurement> { measurement };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.All).Returns(results.AsQueryable());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.CreateMeasurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                  calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreSame(measurement, result);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateMeasurement_RepositoryReturnsMeasurement_ShouldNotCallFactoryCreateMeasurement(int height,
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
            // Arrange
            var date = new DateTime(2, 3, 4);

            var measurement = new Measurement { Date = date, UserId = userId };

            var results = new List<Measurement> { measurement };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.All).Returns(results.AsQueryable());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
           service.CreateMeasurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                  calves, neck, wrist, ankle, userId, date);

            // Assert
            mockedFactory.Verify(f => f.CreateMeasurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                 calves, neck, wrist, ankle, userId, date),
                 Times.Never);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateMeasurement_ShouldCallFactoryCreateMeasurementCorrectly(int height,
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
            var result = service.CreateMeasurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            mockedFactory.Verify(f => f.CreateMeasurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date),
                Times.Once);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateMeasurement_ShouldCallRepositoryAdd(int height,
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

            var measurement = new Measurement();

            var mockedFactory = new Mock<IMeasurementFactory>();
            mockedFactory.Setup(f => f.CreateMeasurement(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(measurement);

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.CreateMeasurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            mockedMeasurementRepository.Verify(n => n.Add(measurement), Times.Once);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateMeasurement_ShouldCallUnitOfWorkCommit(int height,
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

            var measurement = new Measurement();

            var mockedFactory = new Mock<IMeasurementFactory>();
            mockedFactory.Setup(f => f.CreateMeasurement(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(measurement);

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.CreateMeasurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
               calves, neck, wrist, ankle, userId, date);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestCreateMeasurement_ShouldReturnCorrectly(int height,
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

            var measurement = new Measurement();

            var mockedFactory = new Mock<IMeasurementFactory>();
            mockedFactory.Setup(f => f.CreateMeasurement(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(),
               It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
               It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()))
               .Returns(measurement);

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.CreateMeasurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                calves, neck, wrist, ankle, userId, date);

            // Assert
            Assert.AreSame(measurement, result);
        }
    }
}
