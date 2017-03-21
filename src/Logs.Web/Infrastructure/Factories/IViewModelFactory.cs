using CloudinaryDotNet;
using Logs.Models;
using Logs.Web.Models.Home;
using Logs.Web.Models.Logs;
using Logs.Web.Models.Navigation;
using Logs.Web.Models.Profile;
using Logs.Web.Models.Upload;
using PagedList;

namespace Logs.Web.Infrastructure.Factories
{
    public interface IViewModelFactory
    {
        HomeViewModel CreateHomeViewModel(bool isAuthenticated);

        LogEntryViewModel CreateLogEntryViewModel(LogEntry entry, string userId);

        LogDetailsViewModel CreateLogDetailsViewModel(TrainingLog log,
            bool isAuthenticated,
            bool isOwner,
            bool canVote,
            IPagedList<LogEntryViewModel> entries);

        ShortLogViewModel CreateShortLogViewModel(TrainingLog log);

        CreateLogViewModel CreateCreateLogViewModel();

        UserProfileViewModel CreateUserProfileViewModel(User user, bool canEdit);

        UploadViewModel CreateUploadViewModel(Cloudinary cloudinary, string imageUrl);

        NavigationViewModel CreateNavigationViewModel(string username, bool isAuthenticated, bool isAdmin);

        NewLogViewModel CreateNewLogViewModel(int logId);
    }
}
