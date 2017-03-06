using Logs.Web.Models.Home;

namespace Logs.Web.Infrastructure.Factories
{
    public interface IViewModelFactory
    {
        HomeViewModel CreateHomeViewModel(bool isAuthenticated);
    }
}
