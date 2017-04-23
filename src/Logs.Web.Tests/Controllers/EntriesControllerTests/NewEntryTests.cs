﻿using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Models.Entries;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.EntriesControllerTests
{
    [TestFixture]
    public class NewEntryTests
    {
        [Test]
        public void TestNewEntry_ModelStateIsNotValid_ShouldNotCallAuthenticationProviderCurrentUserId()
        {
            // Arrange
            var model = new NewEntryViewModel();

            var mockedService = new Mock<IEntryService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new EntriesController(mockedService.Object, mockedAuthenticationProvider.Object);
            controller.ModelState.AddModelError("", "");

            // Act
            controller.NewEntry(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Never);
        }

        [Test]
        public void TestNewEntry_ShouldCallAuthenticationProviderCurrentUserId()
        {
            // Arrange
            var model = new NewEntryViewModel();

            var mockedService = new Mock<IEntryService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new EntriesController(mockedService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.NewEntry(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase(1, "content", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(5, "much content", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestNewEntry_ShouldCallEntryServiceAddEntryToLogCorrectly(int logId, string content, string userId)
        {
            // Arrange
            var model = new NewEntryViewModel
            {
                LogId = logId,
                Content = content
            };

            var mockedService = new Mock<IEntryService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new EntriesController(mockedService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.NewEntry(model);

            // Assert
            mockedService.Verify(s => s.AddEntryToLog(content, logId, userId), Times.Once);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestNewEntry_ShouldRedirectCorrectly(int logId)
        {
            // Arrange
            var model = new NewEntryViewModel { LogId = logId };

            var mockedService = new Mock<IEntryService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new EntriesController(mockedService.Object, mockedAuthenticationProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.NewEntry(model))
                .ShouldRedirectTo((LogsController c) => c.Details(logId, It.IsAny<int>(), It.IsAny<int>()));
        }
    }
}
