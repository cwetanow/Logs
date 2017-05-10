using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.NutritionServiceTests
{
    [TestFixture]
    public class EditNutritionTests
    {
        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_ShouldCallNutritionRepositoryGetById(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            mockedNutritionRepository.Verify(r => r.GetById(id), Times.Once);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNull_ShouldReturnNull(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldSetCaloriesCorrectly(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(calories, nutrition.Calories);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldSetProteinCorrectly(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(protein, nutrition.Protein);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldSetCarbsCorrectly(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(carbs, nutrition.Carbs);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldSetFatsCorrectly(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(fats, nutrition.Fats);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldSetWaterInLitresCorrectly(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(water, nutrition.WaterInLitres);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldSetFiberCorrectly(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(fiber, nutrition.Fiber);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldSetSugarCorrectly(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(sugar, nutrition.Sugar);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldSetNotesCorrectly(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreEqual(notes, nutrition.Notes);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldCallNutritionRepositoryUpdate(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            mockedNutritionRepository.Verify(r => r.Update(nutrition), Times.Once);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldCallUnitOfWorkCommit(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestEditNutrition_RepositoryReturnsNutrition_ShouldReturnCorrectly(int id, int calories, int protein, int carbs, int fats, double water, int fiber, int sugar, string notes)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedEntryRepository = new Mock<IRepository<NutritionEntry>>();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedNutritionFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedEntryRepository.Object,
                mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedNutritionFactory.Object);

            // Act
            var result = service.EditNutrition(id, calories, protein, carbs, fats, water, fiber, sugar, notes);

            // Assert
            Assert.AreSame(nutrition, result);
        }
    }
}
