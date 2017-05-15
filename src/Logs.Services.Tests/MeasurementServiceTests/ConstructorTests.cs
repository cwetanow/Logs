using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Logs.Services.Tests.MeasurementServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMeasurementFactory = new Mock<IMeasurementFactory>();

            // Act
            var service = new MeasurementService(mockedRepository.Object,
                mockedUnitOfWork.Object,
                mockedMeasurementFactory.Object);

            // Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void TestConstructor_PassRepositoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedMeasurementFactory = new Mock<IMeasurementFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new MeasurementService(null,
                mockedUnitOfWork.Object,
                mockedMeasurementFactory.Object)
            );
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Measurement>>();
            var mockedMeasurementFactory = new Mock<IMeasurementFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new MeasurementService(mockedRepository.Object,
                null,
                mockedMeasurementFactory.Object)
            );
        }

        [Test]
        public void TestConstructor_PassMeasurementFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<Measurement>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new MeasurementService(mockedRepository.Object,
                mockedUnitOfWork.Object,
                null)
            );
        }
    }
}
