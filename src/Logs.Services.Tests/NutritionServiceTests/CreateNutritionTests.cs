using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;
using System;

namespace Logs.Services.Tests.NutritionServiceTests
{
    [TestFixture]
    public class CreateNutritionTests
    {
        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestCreateNutrition_ShouldCallNutritionFactoryCreateNutrition(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var entry = new NutritionEntry();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, entry);

            // Assert
            mockedNutritionFactory.Verify(f => f.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, entry), Times.Once);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestCreateNutrition_ShouldCallNutritionRepositoryAdd(int calories, int protein, int carbs, int fats,
           double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var entry = new NutritionEntry();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var nutrition = new Nutrition();

            var mockedNutritionFactory = new Mock<INutritionFactory>();
            mockedNutritionFactory.Setup(f => f.CreateNutrition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<NutritionEntry>()))
                .Returns(nutrition);

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, entry);

            // Assert
            mockedNutritionRepository.Verify(r => r.Add(nutrition), Times.Once);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestCreateNutrition_ShouldCallUnitOfWorkCommit(int calories, int protein, int carbs, int fats,
           double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var entry = new NutritionEntry();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, entry);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestCreateNutrition_ShouldReturnCorrectly(int calories, int protein, int carbs, int fats,
           double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var entry = new NutritionEntry();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var nutrition = new Nutrition();

            var mockedNutritionFactory = new Mock<INutritionFactory>();
            mockedNutritionFactory.Setup(f => f.CreateNutrition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<NutritionEntry>()))
                .Returns(nutrition);

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, entry);

            // Assert
            Assert.AreSame(nutrition, result);
        }
    }
}