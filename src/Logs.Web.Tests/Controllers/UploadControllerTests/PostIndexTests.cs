﻿using System.Web.Mvc;
using CloudinaryDotNet;
using Logs.Authentication.Contracts;
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
    public class PostIndexTests
    {
        [Test]
        public void TestPostIndex_ModelStateIsNotValid_ShouldNotCallProviderCurrentUserId()
        {
            // Act
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object,
                mockedViewModelFactory.Object);
            controller.ModelState.AddModelError("", "");

            var model = new UploadViewModel();

            // Act
            controller.Index(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Never);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95",
             "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestPostIndex_ShouldCallProviderCurrentUserId(string userId, string pictureUrl)
        {
            // Act
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object,
                mockedViewModelFactory.Object);

            var model = new UploadViewModel { ImageUrl = pictureUrl };

            // Act
            controller.Index(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95",
            "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestPostIndex_ShouldCallUserServiceChangeProfilePicture(string userId, string pictureUrl)
        {
            // Act
            var mockedUserService = new Mock<IUserService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object,
                mockedViewModelFactory.Object);

            var model = new UploadViewModel { ImageUrl = pictureUrl };

            // Act
            controller.Index(model);

            // Assert
            mockedUserService.Verify(s => s.ChangeProfilePicture(userId, pictureUrl), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95",
             "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestPostIndex_ShouldCallCloudinaryFactoryGetCloudinary(string userId, string pictureUrl)
        {
            // Act
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object,
                mockedViewModelFactory.Object);

            var model = new UploadViewModel { ImageUrl = pictureUrl };

            // Act
            controller.Index(model);

            // Assert
            mockedCloudinaryFactory.Verify(cf => cf.GetCloudinary(), Times.Once);
        }


        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95",
            "https://picturethismaths.files.wordpress.com/2016/03/fig6bigforblog.png?w=419&h=364")]
        public void TestPostIndex_ShouldSetViewModelCorrectly(string userId, string pictureUrl)
        {
            // Act
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedCloudinaryFactory = new Mock<ICloudinaryFactory>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            var controller = new UploadController(mockedUserService.Object,
                mockedAuthenticationProvider.Object,
                mockedCloudinaryFactory.Object,
                mockedViewModelFactory.Object);

            var model = new UploadViewModel { ImageUrl = pictureUrl };

            // Act, Assert
            controller
                .WithCallTo(c => c.Index(model))
                .ShouldRenderDefaultView()
                .WithModel<UploadViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
