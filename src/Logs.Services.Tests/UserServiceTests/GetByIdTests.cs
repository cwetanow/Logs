using Logs.Data.Contracts;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class GetByIdTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestGetById_ShouldCallRepositoryGetById(string id)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.GetUserById(id);

            // Assert
            mockedRepository.Verify(r => r.GetById(id), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestGetById_ShoulReturnCorrectly(string id)
        {
            // Arrange
            var mockedUser = new Mock<User>();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(mockedUser.Object);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            var result = service.GetUserById(id);

            // Assert
            Assert.AreSame(mockedUser.Object, result);
        }
    }
}
