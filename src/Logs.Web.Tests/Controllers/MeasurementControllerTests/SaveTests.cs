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

namespace Logs.Web.Tests.Controllers.MeasurementControllerTests
{
    [TestFixture]
    public class SaveTests
    {
        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelStateIsNotValid_ShouldNotCallAuthenticationProviderCurrentUserId(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                  mockedMeasurementService.Object,
                  mockedFactory.Object);
            controller.ModelState.AddModelError("", "");

            // Act
            controller.Save(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Never);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelStateIsNotValid_ShouldRenderCorrectPartialViewWithModel(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                  mockedMeasurementService.Object,
                  mockedFactory.Object);
            controller.ModelState.AddModelError("", "");

            // Act
            controller.Save(model);

            // Assert
            controller
                 .WithCallTo(c => c.Save(model))
                 .ShouldRenderPartialView("Load")
                 .WithModel<MeasurementViewModel>(m => Assert.AreSame(model, m));
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelStateIsValid_ShouldCallAuthenticationProviderCurrentUserId(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                   mockedMeasurementService.Object,
                   mockedFactory.Object);

            // Act
            controller.Save(model);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.CurrentUserId, Times.Once);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdDoesNotHaveValue_ShouldCallServiceCreateMeasurement(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                   mockedMeasurementService.Object,
                   mockedFactory.Object);

            // Act
            controller.Save(model);

            // Assert
            mockedMeasurementService.Verify(s => s.CreateMeasurement(height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                 calves, neck, wrist, ankle, userId, date),
                Times.Once);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdDoesNotHaveValue_ShouldCallFactoryCreateMeasurementViewModelWithResultFromService(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var measurement = new Measurement();

            var mockedMeasurementService = new Mock<IMeasurementService>();
            mockedMeasurementService.Setup(s => s.CreateMeasurement(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(measurement);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                    mockedMeasurementService.Object,
                    mockedFactory.Object);

            // Act
            controller.Save(model);

            // Assert
            mockedFactory.Verify(f => f.CreateMeasurementViewModel(measurement, date), Times.Once);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdDoesNotHaveValue_ShouldSetModelSaveResult(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var measurement = new Measurement();

            var mockedMeasurementService = new Mock<IMeasurementService>();
            mockedMeasurementService.Setup(s => s.CreateMeasurement(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .Returns(measurement);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                  mockedMeasurementService.Object,
                  mockedFactory.Object);

            // Act
            var result = controller.Save(model) as PartialViewResult;

            // Assert
            Assert.AreEqual(Constants.SavedSuccessfully, ((MeasurementViewModel)result.Model).SaveResult);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdDoesNotHaveValue_ShouldRenderCorrectPartialViewWithModel(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var measurement = new Measurement();

            var mockedMeasurementService = new Mock<IMeasurementService>();
            mockedMeasurementService.Setup(s => s.CreateMeasurement(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>(),
                 It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                 It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                 .Returns(measurement);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                   mockedMeasurementService.Object,
                   mockedFactory.Object);

            // Act
            var result = controller.Save(model) as PartialViewResult;

            // Assert
            controller
                 .WithCallTo(c => c.Save(model))
                 .ShouldRenderPartialView("Load")
                 .WithModel<MeasurementViewModel>(m => Assert.AreSame(model, m));
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(14, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdHasValue_ShouldCallServiceEditMeasurement(int id,
                  int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle,
                Id = id
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedMeasurementService = new Mock<IMeasurementService>();

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                  mockedMeasurementService.Object,
                  mockedFactory.Object);

            // Act
            controller.Save(model);

            // Assert
            mockedMeasurementService.Verify(s => s.EditMeasurement(userId, date, id, height, weightKg, bodyFatPercent, chest, shoulders, forearm, arm, waist, hips, thighs,
                 calves, neck, wrist, ankle),
                Times.Once);
        }

        [TestCase(1, 2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(45, 3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdHasValue_ShouldCallFactoryCreateMeasurementViewModelWithResultFromService(int id,
                  int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle,
                Id = id
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var measurement = new Measurement();

            var mockedMeasurementService = new Mock<IMeasurementService>();
            mockedMeasurementService.Setup(s => s.EditMeasurement(It.IsAny<string>(), It.IsAny<DateTime>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>(),
                 It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                 It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(measurement);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                  mockedMeasurementService.Object,
                  mockedFactory.Object);

            // Act
            controller.Save(model);

            // Assert
            mockedFactory.Verify(f => f.CreateMeasurementViewModel(measurement, date), Times.Once);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdHasValue_ShouldSetModelSaveResult(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var measurement = new Measurement();

            var mockedMeasurementService = new Mock<IMeasurementService>();
            mockedMeasurementService.Setup(s => s.EditMeasurement(It.IsAny<string>(), It.IsAny<DateTime>(),
               It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
               .Returns(measurement);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                   mockedMeasurementService.Object,
                   mockedFactory.Object);

            // Act
            var result = controller.Save(model) as PartialViewResult;

            // Assert
            Assert.AreEqual(Constants.SavedSuccessfully, ((MeasurementViewModel)result.Model).SaveResult);
        }

        [TestCase(2222, 100.0, 22, 122, 144, 33, 44, 77, 100, 100, 44, 40, 16, 29, "d547a40d-c45f-4c43-99de-0bfe9199ff95")]
        [TestCase(3333, 67.7, 11.03, 97, 111, 22, 34, 65, 88, 88, 30, 27, 11, 22, "99ae8dd3-1067-4141-9675-62e94bb6caaa")]
        public void TestSave_ModelIdHasValue_ShouldRenderCorrectPartialViewWithModel(int height,
                  double weightKg,
                  double bodyFatPercent,
                  int chest,
                  int shoulders,
                  int forearm,
                  int arm,
                  int waist,
                  int hips,
                  int thighs,
                  int calves,
                  int neck,
                  int wrist,
                  int ankle,
                  string userId)
        {
            // Arrange,
            var date = new DateTime(2, 3, 4);

            var model = new MeasurementViewModel
            {
                Date = date,
                Height = height,
                WeightKg = weightKg,
                BodyFatPercent = bodyFatPercent,
                Chest = chest,
                Shoulders = shoulders,
                Forearm = forearm,
                Arm = arm,
                Waist = waist,
                Hips = hips,
                Thighs = thighs,
                Calves = calves,
                Neck = neck,
                Wrist = wrist,
                Ankle = ankle
            };

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateMeasurementViewModel(It.IsAny<Measurement>(), It.IsAny<DateTime>()))
                .Returns(model);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var measurement = new Measurement();

            var mockedMeasurementService = new Mock<IMeasurementService>();
            mockedMeasurementService.Setup(s => s.EditMeasurement(It.IsAny<string>(), It.IsAny<DateTime>(),
               It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
               .Returns(measurement);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(userId);

            var controller = new MeasurementController(mockedAuthenticationProvider.Object,
                  mockedMeasurementService.Object,
                  mockedFactory.Object);

            // Act
            var result = controller.Save(model) as PartialViewResult;

            // Assert
            controller
                  .WithCallTo(c => c.Save(model))
                  .ShouldRenderPartialView("Load")
                  .WithModel<MeasurementViewModel>(m => Assert.AreSame(model, m));
        }
    }
}
