using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.MeasurementServiceTests
{
    [TestFixture]
    public class DeleteMeasurementTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_ShouldCallRepositoryGetById(int id, string userId)
        {
            // Arrange
            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.DeleteMeasurement(id, userId);

            // Assert
            mockedMeasurementRepository.Verify(r => r.GetById(id), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_RepositoryReturnsNull_ShouldReturnFalse(int id, string userId)
        {
            // Arrange
            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.DeleteMeasurement(id, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_RepositoryReturnsNull_ShouldNotCallRepositoryDelete(int id, string userId)
        {
            // Arrange
            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.DeleteMeasurement(id, userId);

            // Assert
            mockedMeasurementRepository.Verify(r => r.Delete(It.IsAny<Measurement>()), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_RepositoryReturnsMeasurementWithDifferentUserId_ShouldReturnFalse(int id, string userId)
        {
            // Arrange
            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(new Measurement());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.DeleteMeasurement(id, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_RepositoryReturnsMeasurementWithDifferentUserId_ShouldNotCallRepositoryDelete(int id, string userId)
        {
            // Arrange
            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(new Measurement());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.DeleteMeasurement(id, userId);

            // Assert
            mockedMeasurementRepository.Verify(r => r.Delete(It.IsAny<Measurement>()), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_RepositoryReturnsMeasurementWithCorrectUserId_ShouldCallRepositoryDelete(int id, string userId)
        {
            // Arrange
            var measurement = new Measurement { UserId = userId };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.DeleteMeasurement(id, userId);

            // Assert
            mockedMeasurementRepository.Verify(r => r.Delete(It.IsAny<Measurement>()), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_RepositoryReturnsMeasurementWithCorrectUserId_ShouldCallUnitOfWorkCommit(int id, string userId)
        {
            // Arrange
            var measurement = new Measurement { UserId = userId };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.DeleteMeasurement(id, userId);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteMeasurement_RepositoryReturnsMeasurementWithCorrectUserId_ShouldReturnTrue(int id, string userId)
        {
            // Arrange
            var measurement = new Measurement { UserId = userId };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.DeleteMeasurement(id, userId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
