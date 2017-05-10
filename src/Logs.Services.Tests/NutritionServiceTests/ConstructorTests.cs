using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System;

namespace Logs.Services.Tests.NutritionServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            // Act
            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void TestConstructor_PassEntryRepositoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new NutritionService(null,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object)
            );
        }

        [Test]
        public void TestConstructor_PassNutritionRepositoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new NutritionService(mockedEntryRepository.Object,
                null,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object)
            );
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                null,
                mockedNutritionFactory.Object)
            );
        }

        [Test]
        public void TestConstructor_PassNutritionFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                null)
            );
        }
    }
}
