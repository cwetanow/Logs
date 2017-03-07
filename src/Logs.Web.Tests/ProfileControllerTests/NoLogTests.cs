﻿using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.ProfileControllerTests
{
    [TestFixture]
    public class NoLogTests
    {
        [Test]
        public void TestNoLog_ShouldReturnView()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedService = new Mock<IUserService>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            // Act
            var result = controller.NoLog();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
