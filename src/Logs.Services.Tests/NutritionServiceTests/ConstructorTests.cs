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
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            // Act
            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void TestConstructor_PassNutritionRepositoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new NutritionService(null,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object)
            );
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new NutritionService(mockedNutritionRepository.Object,
                null,
                mockedNutritionFactory.Object)
            );
        }

        [Test]
        public void TestConstructor_PassNutritionFactoryNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                null)
            );
        }
    }
}
