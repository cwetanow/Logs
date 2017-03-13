using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        public void TestGetByUsername_ShouldCallRepositoryGetAllCorrectly(string username)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.GetUserByUsername(username);

            // Assert
            mockedRepository.Verify(r => r.GetAll(It.IsAny<Expression<Func<User, bool>>>()), Times.Once());
        }

        [TestCase("username")]
        [TestCase("myUsername")]
        public void TestGetByUsername_ShouldReturnCorrectly(string username)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetAll(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new List<User> { user });

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            var result = service.GetUserByUsername(username);

            // Assert
            Assert.AreSame(user, result);
        }
    }
}
