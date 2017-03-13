using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.ProfileControllerTests
{
    [TestFixture]
    public class EditTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5)]
        public void TestEdit_ShouldCallServiceEditUserCorrectly(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedService = new Mock<IUserService>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            var model = new User { Id = userId, Description = description, Age = age, Weight = weight, Height = height, BodyFatPercent = bodyFat };

            // Act
            controller.Edit(model);

            // Assert
            mockedService.Verify(s => s.EditUser(userId, description, age, weight, height, bodyFat), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", "description", 18, 92.5, 181, 13.5)]
        public void TestEdit_ShouldSetViewModel(string userId,
            string description,
            int age,
            double weight,
            int height,
            double bodyFat)
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedService = new Mock<IUserService>();

            var controller = new ProfileController(mockedProvider.Object, mockedService.Object);

            var model = new User { Id = userId, Description = description, Age = age, Weight = weight, Height = height, BodyFatPercent = bodyFat };

            // Act
            var result = controller.Edit(model);

            // Assert
            Assert.AreSame(model, result.Model);
        }
    }
}
