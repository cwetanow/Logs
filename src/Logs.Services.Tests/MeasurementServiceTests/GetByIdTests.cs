using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.MeasurementServiceTests
{
    [TestFixture]
    public class GetByIdTests
    {
        [TestCase(1)]
        [TestCase(453)]
        [TestCase(13)]
        public void TestGetById_ShouldCallRepositoryGetByIdCorrectly(int id)
        {
            // Arrange
            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.GetById(id);

            // Assert
            mockedMeasurementRepository.Verify(r => r.GetById(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(453)]
        [TestCase(13)]
        public void TestGetById_RepositoryReturnsMeasurement_ShouldReturnCorrectly(int id)
        {
            // Arrange
            var measurement = new Measurement();

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(measurement);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            Assert.AreSame(measurement, result);
        }
    }
}
