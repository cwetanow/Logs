using Logs.Authentication.Contracts;
using Logs.Common;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;
using Moq;
using NUnit.Framework;
using System;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.NutritionControllerTests
{
    [TestFixture]
    public class SaveEntryTests
    {
        [Test]
        public void TestSaveEntry_ModelStateIsNotValid_ShouldNotCallAuthenticationProviderCurrentUserId()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);
            controller.ModelState.AddModelError("", "");

            // Act
            controller.SaveEntry(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Never);
        }

        [Test]
        public void TestSaveEntry_ModelStateIsNotValid_ShouldRenderCorrectPartialViewWithModel()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);
            controller.ModelState.AddModelError("", "");

            // Act, Assert
            controller
                .WithCallTo(c => c.SaveEntry(model))
                .ShouldRenderPartialView("NutritionEditPartial")
                .WithModel<NutritionViewModel>(m => Assert.AreSame(model, m));
        }

        [Test]
        public void TestSaveEntry_ModelStateIsValid_ShouldCallAuthenticationProviderCurrentUserId()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.SaveEntry(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestSaveEntry_ModelStateIsValid_ShouldCallNutritionServiceUpdateNutritionCorrectly(int id, string userId, int calories,
            int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var date = new DateTime();

            var model = new NutritionViewModel
            {
                Id = id,
                Date = date,
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes
            };

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.SaveEntry(model);

            // Assert
            mockedNutritionService.Verify(s => s.UpdateNutrition(id, userId, date, calories, protein, carbs, fats, water, fiber, sugar, notes),
                Times.Once);
        }

        [Test]
        public void TestSaveEntry_ServiceReturnsNull_ShouldNotSetModelSaveResultToConstantsSavedSuccessfully()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = controller.SaveEntry(model) as PartialViewResult;

            // Assert
            Assert.AreNotEqual(Constants.SavedSuccessfully, ((NutritionViewModel)result.Model).SaveResult);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestSaveEntry_ServiceReturnsNutrition_ShouldSetViewModelCaloriesCorrectly(int id, string userId, int calories,
            int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition
            {
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes
            };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.UpdateNutrition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = (NutritionViewModel)(controller.SaveEntry(model) as PartialViewResult).Model;

            // Assert
            Assert.AreEqual(calories, result.Calories);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestSaveEntry_ServiceReturnsNutrition_ShouldSetViewModelCarbsCorrectly(int id, string userId, int calories,
            int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition
            {
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes
            };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.UpdateNutrition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = (NutritionViewModel)(controller.SaveEntry(model) as PartialViewResult).Model;

            // Assert
            Assert.AreEqual(carbs, result.Carbs);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestSaveEntry_ServiceReturnsNutrition_ShouldSetViewModelFatsCorrectly(int id, string userId, int calories,
            int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition
            {
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes
            };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.UpdateNutrition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = (NutritionViewModel)(controller.SaveEntry(model) as PartialViewResult).Model;

            // Assert
            Assert.AreEqual(fats, result.Fats);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestSaveEntry_ServiceReturnsNutrition_ShouldSetViewModelFiberCorrectly(int id, string userId, int calories,
            int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition
            {
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes
            };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.UpdateNutrition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = (NutritionViewModel)(controller.SaveEntry(model) as PartialViewResult).Model;

            // Assert
            Assert.AreEqual(fiber, result.Fiber);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestSaveEntry_ServiceReturnsNutrition_ShouldSetViewModelNotesCorrectly(int id, string userId, int calories,
            int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition
            {
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes
            };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.UpdateNutrition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = (NutritionViewModel)(controller.SaveEntry(model) as PartialViewResult).Model;

            // Assert
            Assert.AreEqual(notes, result.Notes);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestSaveEntry_ServiceReturnsNutrition_ShouldSetViewModelProteinCorrectly(int id, string userId, int calories,
            int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition
            {
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes
            };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.UpdateNutrition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = (NutritionViewModel)(controller.SaveEntry(model) as PartialViewResult).Model;

            // Assert
            Assert.AreEqual(protein, result.Protein);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestSaveEntry_ServiceReturnsNutrition_ShouldSetViewModelSugarCorrectly(int id, string userId, int calories,
            int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition
            {
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes
            };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.UpdateNutrition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = (NutritionViewModel)(controller.SaveEntry(model) as PartialViewResult).Model;

            // Assert
            Assert.AreEqual(sugar, result.Sugar);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestSaveEntry_ServiceReturnsNutrition_ShouldSetViewModelWaterInLitresCorrectly(int id, string userId, int calories,
            int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition
            {
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes
            };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.UpdateNutrition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = (NutritionViewModel)(controller.SaveEntry(model) as PartialViewResult).Model;

            // Assert
            Assert.AreEqual(water, result.WaterInLitres);
        }

        [TestCase(1, "d547a40d-c45f-4c43-99de-0bfe9199ff95", 2222, 222, 111, 99, 3.17, 22, 7, "good")]
        [TestCase(13, "99ae8dd3-1067-4141-9675-62e94bb6caaa", 3333, 231, 771, 44, 5, 33, 6, "no notes")]
        public void TestSaveEntry_ServiceReturnsNutrition_ShouldSetViewModelSaveResultCorrectly(int id, string userId, int calories,
            int protein, int carbs, int fats, double water,
            int fiber, int sugar, string notes)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition
            {
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes
            };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.UpdateNutrition(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = (NutritionViewModel)(controller.SaveEntry(model) as PartialViewResult).Model;

            // Assert
            Assert.AreEqual(Constants.SavedSuccessfully, result.SaveResult);
        }

        [Test]
        public void TestSaveEntry_ModelStateIsValid_ShouldRenderCorrectPartialViewWithModel()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var model = new NutritionViewModel();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);
            controller.ModelState.AddModelError("", "");

            // Act, Assert
            controller
                .WithCallTo(c => c.SaveEntry(model))
                .ShouldRenderPartialView("NutritionEditPartial")
                .WithModel<NutritionViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
