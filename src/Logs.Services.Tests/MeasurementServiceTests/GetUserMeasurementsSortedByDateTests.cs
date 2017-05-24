using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Logs.Services.Tests.MeasurementServiceTests
{
    [TestFixture]
    public class GetUserMeasurementsSortedByDateTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestGetUserMeasurementsSortedByDate_ShouldCallRepositoryAll(string userId)
        {
            // Arrange
            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.GetUserMeasurementsSortedByDate(userId);

            // Assert
            mockedMeasurementRepository.Verify(r => r.All, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestGetUserMeasurementsSortedByDate_ShouldFilterAndReturnCorrectly(string userId)
        {
            // Arrange
            var measurements = new List<Measurement>
            {
                new Measurement {UserId=userId },
                new Measurement {UserId=userId },
                new Measurement ()
            }.AsQueryable();

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.All).Returns(measurements);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            var expected = measurements.Where(m => m.UserId == userId);

            // Act
            var result = service.GetUserMeasurementsSortedByDate(userId);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
