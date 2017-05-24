using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.NutritionServiceTests
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
            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            service.GetById(id);

            // Assert
            mockedNutritionRepository.Verify(r => r.GetById(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(453)]
        [TestCase(13)]
        public void TestGetById_RepositoryReturnsNutrition_ShouldReturnCorrectly(int id)
        {
            // Arrange
            var nutrition = new Nutrition();

            var mockedNutritionRepository = new Mock<IRepository<Nutrition>>();
            mockedNutritionRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(nutrition);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedFactory = new Mock<INutritionFactory>();

            var service = new NutritionService(mockedNutritionRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            Assert.AreSame(nutrition, result);
        }
    }
}
