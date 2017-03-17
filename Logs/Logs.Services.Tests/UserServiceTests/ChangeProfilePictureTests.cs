using Logs.Data.Contracts;
using Logs.Models;
using Moq;
using NUnit.Framework;

namespace Logs.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class ChangeProfilePictureTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestEditUser_ShouldCallRepositoryGetById(string userId,
            string imageUrl)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.ChangeProfilePicture(userId, imageUrl);

            // Assert
            mockedRepository.Verify(r => r.GetById(userId), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestEditUser_RepositoryReturnsNull_ShouldNotCallUnitOfWorkCommit(string userId,
            string imageUrl)
        {
            // Arrange
            var mockedRepository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.ChangeProfilePicture(userId, imageUrl);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Never);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestEditUser_RepositoryReturnsUser_ShouldSetUserDescriptionCorrectly(string userId,
            string imageUrl)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.ChangeProfilePicture(userId, imageUrl);

            // Assert
            Assert.AreEqual(imageUrl, user.ProfileImageUrl);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestEditUser_RepositoryReturnsUser_ShouldCallRepositoryUpdateCorrectly(string userId,
            string imageUrl)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.ChangeProfilePicture(userId, imageUrl);

            // Assert
            mockedRepository.Verify(r => r.Update(user), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestEditUser_RepositoryReturnsUser_ShouldCallUnitOfWorkCommit(string userId,
            string imageUrl)
        {
            // Arrange
            var user = new User();

            var mockedRepository = new Mock<IRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(user);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

            // Act
            service.ChangeProfilePicture(userId, imageUrl);

            // Assert
            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }
    }
}
