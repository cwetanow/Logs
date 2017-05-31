using System;
using CloudinaryDotNet;
using Logs.Models;
using Logs.Web.Models.Home;
using Logs.Web.Models.Logs;
using Logs.Web.Models.Navigation;
using Logs.Web.Models.Nutrition;
using Logs.Web.Models.Profile;
using Logs.Web.Models.Upload;
using PagedList;
using System.Collections.Generic;
using Logs.Web.Areas.Users.Models;

namespace Logs.Web.Infrastructure.Factories
{
    public interface IViewModelFactory
    {
        HomeViewModel CreateHomeViewModel(bool isAuthenticated);

        LogEntryViewModel CreateLogEntryViewModel(LogEntry entry, string userId);

        LogDetailsViewModel CreateLogDetailsViewModel(TrainingLog log,
            bool isAuthenticated,
            bool canEdit,
            bool canVote,
            IPagedList<LogEntryViewModel> entries);

        ShortLogViewModel CreateShortLogViewModel(TrainingLog log);

        CreateLogViewModel CreateCreateLogViewModel();

        UserProfileViewModel CreateUserProfileViewModel(User user, bool canEdit);

        UploadViewModel CreateUploadViewModel(Cloudinary cloudinary, string imageUrl);

        NavigationViewModel CreateNavigationViewModel(string username, bool isAuthenticated, bool isAdmin);

        NewLogViewModel CreateNewLogViewModel(int logId);

        InputViewModel CreateInputViewModel(DateTime date);

        MeasurementViewModel CreateMeasurementViewModel(Measurement measurement, DateTime date);

        NutritionViewModel CreateNutritionViewModel(Nutrition nutrition, DateTime date);

        MeasurementStatsViewModel CreateMeasurementStatsViewModel(IEnumerable<Measurement> measurements);

        NutritionStatsViewModel CreateNutritionStatsViewModel(IEnumerable<Nutrition> nutritions);

        UserIdViewModel CreateUserIdViewModel(string userId);
    }
}
