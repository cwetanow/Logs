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
    public class SaveTests
    {
        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelStateIsNotValid_ShouldNotCallAuthenticationProviderCurrentUserId(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
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

            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);
            controller.ModelState.AddModelError("", "");

            // Act
            controller.Save(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Never);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelStateIsNotValid_ShouldRenderCorrectPartialViewWithModel(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
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

            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);
            controller.ModelState.AddModelError("", "");

            // Act
            controller.Save(model);

            // Assert
            controller
                 .WithCallTo(c => c.Save(model))
                 .ShouldRenderPartialView("Load")
                 .WithModel<NutritionViewModel>(m => Assert.AreSame(model, m));
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelStateIsValid_ShouldCallAuthenticationProviderCurrentUserId(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
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

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Save(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdDoesNotHaveValue_ShouldCallServiceCreateNutrition(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
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

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Save(model);

            // Assert
            mockedNutritionService.Verify(s => s.CreateNutrition(calories, protein, carbs, fats, water, fiber, sugar, notes, userId, date),
                Times.Once);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdDoesNotHaveValue_ShouldCallFactoryCreateNutritionViewModelWithResultFromService(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
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

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition();

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.CreateNutrition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Save(model);

            // Assert
            mockedFactory.Verify(f => f.CreateNutritionViewModel(nutrition, date), Times.Once);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdDoesNotHaveValue_ShouldSetModelSaveResult(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
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

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition();

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.CreateNutrition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = controller.Save(model) as PartialViewResult;

            // Assert
            Assert.AreEqual(Constants.SavedSuccessfully, ((NutritionViewModel)result.Model).SaveResult);
        }

        [TestCase(2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdDoesNotHaveValue_ShouldRenderCorrectPartialViewWithModel(int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
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

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition();

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.CreateNutrition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = controller.Save(model) as PartialViewResult;

            // Assert
            controller
                 .WithCallTo(c => c.Save(model))
                 .ShouldRenderPartialView("Load")
                 .WithModel<NutritionViewModel>(m => Assert.AreSame(model, m));
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(22, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdHasValue_ShouldCallServiceEditNutrition(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
                Date = date,
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes,
                Id = id
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Save(model);

            // Assert
            mockedNutritionService.Verify(s => s.EditNutrition(userId, date, id, calories, protein, carbs, fats, water, fiber, sugar, notes),
                Times.Once);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(22, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdHasValue_ShouldCallFactoryCreateNutritionViewModelWithResultFromService(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
                Date = date,
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes,
                Id = id
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition();

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.EditNutrition(It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.Save(model);

            // Assert
            mockedFactory.Verify(f => f.CreateNutritionViewModel(nutrition, date), Times.Once);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(22, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdHasValue_ShouldSetModelSaveResult(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
                Date = date,
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes,
                Id = id
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition();

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.EditNutrition(It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = controller.Save(model) as PartialViewResult;

            // Assert
            Assert.AreEqual(Constants.SavedSuccessfully, ((NutritionViewModel)result.Model).SaveResult);
        }

        [TestCase(1, 2222, 222, 111, 99, 3.17, 22, 7, "good", "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(22, 3333, 231, 771, 44, 5, 33, 6, "no notes", "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdHasValue_ShouldRenderCorrectPartialViewWithModel(int id, int calories, int protein, int carbs, int fats,
            double water, int fiber, int sugar, string notes, string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new NutritionViewModel
            {
                Date = date,
                Calories = calories,
                Protein = protein,
                Carbs = carbs,
                Fats = fats,
                WaterInLitres = water,
                Fiber = fiber,
                Sugar = sugar,
                Notes = notes,
                Id = id
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition();

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.EditNutrition(It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(nutrition);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = controller.Save(model) as PartialViewResult;

            // Assert
            controller
                  .WithCallTo(c => c.Save(model))
                  .ShouldRenderPartialView("Load")
                  .WithModel<NutritionViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
