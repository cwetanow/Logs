using System.Web.Mvc;
using CloudinaryDotNet;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Upload;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.UploadControllerTests
{
    [TestFixture]
    public class IndexTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95",
            "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestIndex_ShouldCallProviderCurrentUserId(string userId, string pictureUrl)
        {
            // Act
            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>()))
                .Returns(new User { ProfileImageUrl = pictureUrl });

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();

            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(f => f.CreateUploadViewModel(It.IsAny<Cloudinary>(), It.IsAny<string>()))
                .Returns((Cloudinary c, string imageUrl) => new UploadViewModel(c, imageUrl));

            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object,
                mockedViewModelFactory.Object);


            // Act
            controller.Index();

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95",
           "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestIndex_ShouldCallUserServiceGetUserByIdCorrectly(string userId, string pictureUrl)
        {
            // Act
            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>()))
                .Returns(new User { ProfileImageUrl = pictureUrl });

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();

            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(f => f.CreateUploadViewModel(It.IsAny<Cloudinary>(), It.IsAny<string>()))
                .Returns((Cloudinary c, string imageUrl) => new UploadViewModel(c, imageUrl));

            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object,
                mockedViewModelFactory.Object);


            // Act
            controller.Index();

            // Assert
            mockedUserService.Verify(s => s.GetUserById(userId), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95",
           "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestIndex_ShouldCallCloudinaryFactoryGetCloudinary(string userId, string pictureUrl)
        {
            // Act
            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>()))
                .Returns(new User { ProfileImageUrl = pictureUrl });

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();

            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(f => f.CreateUploadViewModel(It.IsAny<Cloudinary>(), It.IsAny<string>()))
                .Returns((Cloudinary c, string imageUrl) => new UploadViewModel(c, imageUrl));

            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object,
                mockedViewModelFactory.Object);


            // Act
            controller.Index();

            // Assert
            mockedCloudinaryFactory.Verify(f => f.GetCloudinary(), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95",
           "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestIndex_ShouldCallViewModelFactoryCreateUploadViewModel(string userId, string pictureUrl)
        {
            // Act
            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>()))
                .Returns(new User { ProfileImageUrl = pictureUrl });

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();

            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(f => f.CreateUploadViewModel(It.IsAny<Cloudinary>(), It.IsAny<string>()))
                .Returns((Cloudinary c, string imageUrl) => new UploadViewModel(c, imageUrl));

            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object,
                mockedViewModelFactory.Object);


            // Act
            controller.Index();

            // Assert
            mockedViewModelFactory.Verify(f => f.CreateUploadViewModel(It.IsAny<Cloudinary>(), pictureUrl), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95",
           "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestIndex_ShouldSetViewModelCorrectly(string userId, string pictureUrl)
        {
            // Act
            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetUserById(It.IsAny<string>()))
                .Returns(new User { ProfileImageUrl = pictureUrl });

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();

            var model = new UploadViewModel();

            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(f => f.CreateUploadViewModel(It.IsAny<Cloudinary>(), It.IsAny<string>()))
                .Returns(model);

            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object,
                mockedViewModelFactory.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<UploadViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
