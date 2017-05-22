using System;
using System.Collections.Generic;
using System.Linq;
using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.MeasurementServiceTests
{
    [TestFixture]
    public class GetByDateTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        public void TestGetByDate_ShouldCallRepositoryAll(string userId)
        {
            // Arrange
            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.GetByDate(userId, new DateTime());

            // Assert
            mockedMeasurementRepository.Verify(r => r.All, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 29, 7, 1999)]
        public void TestGetByDate_ThereIsNoEntry_ShouldReturnNull(string userId, int day, int month, int year)
        {
            // Arrange
            var date = new DateTime(year, month, day);
            var measurement = new Measurement();

            var results = new List<Measurement> { measurement };

            var mockedMeasurementRepository = new Mock<IRepository<Measurement>>();
            mockedMeasurementRepository.Setup(r => r.All).Returns(results.AsQueryable());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<IMeasurementFactory>();

            var service = new MeasurementService(mockedMeasurementRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.GetByDate(userId, date);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 11, 11, 1111)]
        public void TestGetByDate_ThereIsEntry_ShouldReturnCorrectly(string userId, int day, int month, int year)
        {
            // Arrange
            var date = new DateTime(year, month, day);
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
            var result = service.GetByDate(userId, date);

            // Assert
            Assert.AreSame(measurement, result);
        }
    }
}