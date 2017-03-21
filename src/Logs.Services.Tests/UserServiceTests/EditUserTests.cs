using Logs.Data.Contracts;
using Logs.Models;
using Logs.Models.Enumerations;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class EditUserTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5, GenderType.Male)]
        public void TestEditUser_ShouldCallRepositoryGetById(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat,
            GenderType genderType)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.EditUser(userId, description, age, weight, height, bodyFat, genderType);

            // Assert
            mockedRepository.Verify(r => r.GetById(userId), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5, GenderType.Male)]
        public void TestEditUser_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat,
            GenderType genderType)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.EditUser(userId, description, age, weight, height, bodyFat, genderType);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5, GenderType.Male)]
        public void TestEditUser_RepositoryReturnsUser_ShouldSetUserDescriptionCorrectly(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat,
            GenderType genderType)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.EditUser(userId, description, age, weight, height, bodyFat, genderType);

            // Assert
            Assert.AreEqual(description, user.Description);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5, GenderType.Male)]
        public void TestEditUser_RepositoryReturnsUser_ShouldSetUserAgeCorrectly(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat,
            GenderType genderType)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.EditUser(userId, description, age, weight, height, bodyFat, genderType);

            // Assert
            Assert.AreEqual(age, user.Age);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5, GenderType.Male)]
        public void TestEditUser_RepositoryReturnsUser_ShouldSetUserWeightCorrectly(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat,
            GenderType genderType)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.EditUser(userId, description, age, weight, height, bodyFat, genderType);

            // Assert
            Assert.AreEqual(weight, user.Weight);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5, GenderType.Male)]
        public void TestEditUser_RepositoryReturnsUser_ShouldSetUserHeightCorrectly(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat,
            GenderType genderType)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.EditUser(userId, description, age, weight, height, bodyFat, genderType);

            // Assert
            Assert.AreEqual(height, user.Height);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5, GenderType.Male)]
        public void TestEditUser_RepositoryReturnsUser_ShouldSetUserBodyFatPercentCorrectly(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat,
            GenderType genderType)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.EditUser(userId, description, age, weight, height, bodyFat, genderType);

            // Assert
            Assert.AreEqual(bodyFat, user.BodyFatPercent);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5, GenderType.Male)]
        public void TestEditUser_RepositoryReturnsUser_ShouldSetUserGenderTypeCorrectly(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat,
            GenderType genderType)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.EditUser(userId, description, age, weight, height, bodyFat, genderType);

            // Assert
            Assert.AreEqual(genderType, user.GenderType);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5, GenderType.Male)]
        public void TestEditUser_RepositoryReturnsUser_ShouldCallRepositoryUpdateCorrectly(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat,
            GenderType genderType)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.EditUser(userId, description, age, weight, height, bodyFat, genderType);

            // Assert
            mockedRepository.Verify(r => r.Update(user), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5, GenderType.Male)]
        public void TestEditUser_RepositoryReturnsUser_ShouldCallUnitOfWorkCommit(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat,
            GenderType genderType)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.EditUser(userId, description, age, weight, height, bodyFat, genderType);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }
    }
}
