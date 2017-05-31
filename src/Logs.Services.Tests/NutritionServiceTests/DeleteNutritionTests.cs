using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.NutritionServiceTests
{
    [TestFixture]
    public class DeleteNutritionTests
    {
        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_ShouldCallRepositoryGetById(int id, string userId)
        {
            // Arrange
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.DeleteNutrition(id, userId);

            // Assert
            mockedNutritionRepository.Verify(r => r.GetById(id), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_RepositoryReturnsNull_ShouldReturnFalse(int id, string userId)
        {
            // Arrange
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.DeleteNutrition(id, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_RepositoryReturnsNull_ShouldNotCallRepositoryDelete(int id, string userId)
        {
            // Arrange
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.DeleteNutrition(id, userId);

            // Assert
            mockedNutritionRepository.Verify(r => r.Delete(It.IsAny<Nutrition>()), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_RepositoryReturnsNutritionWithDifferentUserId_ShouldReturnFalse(int id, string userId)
        {
            // Arrange
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(new Nutrition());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.DeleteNutrition(id, userId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_RepositoryReturnsNutritionWithDifferentUserId_ShouldNotCallRepositoryDelete(int id, string userId)
        {
            // Arrange
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(new Nutrition());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.DeleteNutrition(id, userId);

            // Assert
            mockedNutritionRepository.Verify(r => r.Delete(It.IsAny<Nutrition>()), Times.Never);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_RepositoryReturnsNutritionWithCorrectUserId_ShouldCallRepositoryDelete(int id, string userId)
        {
            // Arrange
            var nutrition = new Nutrition { UserId = userId };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.DeleteNutrition(id, userId);

            // Assert
            mockedNutritionRepository.Verify(r => r.Delete(It.IsAny<Nutrition>()), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_RepositoryReturnsNutritionWithCorrectUserId_ShouldCallUnitOfWorkCommit(int id, string userId)
        {
            // Arrange
            var nutrition = new Nutrition { UserId = userId };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.DeleteNutrition(id, userId);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestDeleteNutrition_RepositoryReturnsNutritionWithCorrectUserId_ShouldReturnTrue(int id, string userId)
        {
            // Arrange
            var nutrition = new Nutrition { UserId = userId };

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.DeleteNutrition(id, userId);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
