using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.NutritionControllerTests
{
    [TestFixture]
    public class GetNutritionTests
    {
        [TestCase(1)]
        [TestCase(6)]
        [TestCase(1457)]
        [TestCase(13)]
        public void TestGetNutrition_ShouldCallSeasurementServiceGetById(int id)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
             mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.GetNutrition(id);

            // Assert
            mockedNutritionService.Verify(s => s.GetById(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(1457)]
        [TestCase(13)]
        public void TestGetNutrition_ServiceReturnsNull_ShouldRenderPartialViewWithModelNull(int id)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
             mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.GetNutrition(id))
                .ShouldRenderPartialView("NutritionDetails");
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(1457)]
        [TestCase(13)]
        public void TestGetNutrition_ServiceReturnsNutrition_ShouldCallFactoryCreateNutritionViewModel(int id)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);

            var nutrition = new Nutrition { Date = date };

            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.GetById(It.IsAny<int>())).Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
              mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.GetNutrition(id);

            // Assert
            mockedFactory.Verify(f => f.CreateNutritionViewModel(nutrition, date), Times.Once);
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(1457)]
        [TestCase(13)]
        public void TestGetNutrition_ServiceReturnsNutrition_ShouldRenderPartialViewWithModel(int id)
        {
            // Arrange
            var date = new DateTime(1, 2, 3);

            var nutrition = new Nutrition { Date = date };

            var model = new NutritionViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.GetById(It.IsAny<int>())).Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
             mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.GetNutrition(id))
                .ShouldRenderPartialView("NutritionDetails")
                .WithModel<NutritionViewModel>(model);
        }
    }
}
