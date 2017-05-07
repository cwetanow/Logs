using System;
using Logs.Authentication.Contracts;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Controllers;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Nutrition;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace Logs.Web.Tests.Controllers.NutritionControllerTests
{
    [TestFixture]
    public class LoadEntryTests
    {
        [Test]
        public void TestLoadEntry_ModelStateIsNotValid_ShouldReturnNull()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);
            controller.ModelState.AddModelError("", "");

            // Act
            var result = controller.LoadEntry(new InputViewModel());

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void TestLoadEntry_ModelStateIsValid_ShouldCallAuthenticationProviderCurrentUserId()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.LoadEntry(new InputViewModel());

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestLoadEntry_ModelStateIsValid_ShouldCallNutritionServiceGetEntryByDate(string userId)
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.LoadEntry(model);

            // Assert
            mockedNutritionService.Verify(s => s.GetEntryByDate(userId, date), Times.Once);
        }

        [Test]
        public void TestLoadEntry_EntryIsNull_ShouldCallFactoryCreateMeasurementViewModelWithNull()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.LoadEntry(model);

            // Assert
            mockedFactory.Verify(f => f.CreateMeasurementViewModel(null, date));
        }

        [Test]
        public void TestLoadEntry_EntryIsNotNull_ShouldCallFactoryCreateMeasurementViewModelCorrectly()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var measurement = new Measurement();
            var entry = new NutritionEntry();
            entry.Measurement = measurement;

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.GetEntryByDate(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(entry);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.LoadEntry(model);

            // Assert
            mockedFactory.Verify(f => f.CreateMeasurementViewModel(measurement, date));
        }

        [Test]
        public void TestLoadEntry_EntryIsNull_ShouldCallFactoryCreateNutritionViewModelWithNull()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.LoadEntry(model);

            // Assert
            mockedFactory.Verify(f => f.CreateNutritionViewModel(null, date));
        }

        [Test]
        public void TestLoadEntry_EntryIsNotNull_ShouldCallFactoryCreateNutritionViewModelCorrectly()
        {
            // Arrange
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var nutrition = new Nutrition();
            var entry = new NutritionEntry { Nutrition = nutrition };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.GetEntryByDate(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(entry);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.LoadEntry(model);

            // Assert
            mockedFactory.Verify(f => f.CreateNutritionViewModel(nutrition, date));
        }

        [Test]
        public void TestLoadEntry_EntryIsNull_ShouldCallFactoryCreateNutritionEntryViewModelWithZero()
        {
            // Arrange
            var measurementViewModel = new MeasurementViewModel();
            var nutritionViewModel = new NutritionViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(nutritionViewModel);
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
               .Returns(measurementViewModel);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            var expectedId = 0;

            // Act
            controller.LoadEntry(model);

            // Assert
            mockedFactory.Verify(f => f.CreateNutritionEntryViewModel(expectedId, date, nutritionViewModel, measurementViewModel),
                Times.Once);
        }

        [TestCase(1)]
        [TestCase(415)]
        [TestCase(13)]
        public void TestLoadEntry_EntryIsNotNull_ShouldCallFactoryCreateNutritionEntryViewModelCorrectly(int entryId)
        {
            // Arrange
            var measurementViewModel = new MeasurementViewModel();
            var nutritionViewModel = new NutritionViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionViewModel(It.IsAny<Nutrition>(), It.IsAny<DateTime>()))
                .Returns(nutritionViewModel);
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
               .Returns(measurementViewModel);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var entry = new NutritionEntry { NutritionEntryId = entryId };

            var mockedNutritionService = new Mock<INutritionService>();
            mockedNutritionService.Setup(s => s.GetEntryByDate(It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(entry);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.LoadEntry(model);

            // Assert
            mockedFactory.Verify(f => f.CreateNutritionEntryViewModel(entryId, date, nutritionViewModel, measurementViewModel),
                Times.Once);
        }

        [Test]
        public void TestLoadEntry_EntryIsNotNull_ShouldCallFactoryCreateNutritionEntryViewModelCorrectly()
        {
            // Arrange
            var viewModel = new NutritionEntryViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateNutritionEntryViewModel(It.IsAny<int>(), It.IsAny<DateTime>(),
                    It.IsAny<NutritionViewModel>(), It.IsAny<MeasurementViewModel>()))
                .Returns(viewModel);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedNutritionService = new Mock<INutritionService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var date = new DateTime(2, 3, 4);
            var model = new InputViewModel { Date = date };

            var controller = new NutritionController(mockedFactory.Object, mockedDateTimeProvider.Object,
            mockedNutritionService.Object, mockedAuthenticationProvider.Object);

            // Act, Assert
            controller
                .WithCallTo(c => c.LoadEntry(model))
                .ShouldRenderPartialView("NutritionEntryPartial")
                .WithModel<NutritionEntryViewModel>(m => Assert.AreSame(viewModel, m));
        }
    }
}
