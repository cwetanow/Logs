using System.Collections.Generic;
using System.Linq;
using Logs.Data.Contracts;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class GetUsersTests
    {
        [Test]
        public void TestGetUsers_ShouldCallRepositoryGetAll()
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.GetUsers();

            // Assert
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void TestGetUsers_ShouldReturnCorrectResult()
        {
            // Arrange
            var users = new List<User> { new User() }
                .AsQueryable();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.All).Returns(users);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            var result = service.GetUsers();

            // Assert
            CollectionAssert.AreEqual(users, result);
        }
    }
}
