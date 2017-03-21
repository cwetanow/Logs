using System.Collections.Generic;
using System.Linq;
using Logs.Data.Contracts;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class GetByUsernameTests
    {
        [TestCase("username")]
        [TestCase("myUsername")]
        public void TestGetByUsername_ShouldCallRepositoryAllCorrectly(string username)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.GetUserByUsername(username);

            // Assert
            mockedRepository.Verify(r => r.All, Times.Once());
        }

        [TestCase("username")]
        [TestCase("myUsername")]
        public void TestGetByUsername_ShouldReturnCorrectly(string username)
        {
            // Arrange
            var user = new User { UserName = username };

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.All)
                .Returns(new List<User> { user }.AsQueryable());

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            var result = service.GetUserByUsername(username);

            // Assert
            Assert.AreSame(user, result);
        }
    }
}
