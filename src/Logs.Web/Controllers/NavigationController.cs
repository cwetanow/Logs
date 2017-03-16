using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Web.Infrastructure.Factories;

namespace Logs.Web.Controllers
{
    public class NavigationController : Controller
    {
        private const string AdministratorRoleName = "administrator";

        private readonly IAuthenticationProvider authenticationProvider;
        private readonly IViewModelFactory viewModelFactory;

        public NavigationController(IAuthenticationProvider authenticationProvider, IViewModelFactory viewModelFactory)
        {
            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.viewModelFactory = viewModelFactory;
            this.authenticationProvider = authenticationProvider;
        }

        public ActionResult Index()
        {
            var isAuthenticated = this.authenticationProvider.IsAuthenticated;
            var username = string.Empty;
            var isAdmin = false;

            if (isAuthenticated)
            {
                username = this.authenticationProvider.CurrentUserUsername;
                var userId = this.authenticationProvider.CurrentUserId;

                isAdmin = this.authenticationProvider.IsInRole(userId, AdministratorRoleName);
            }

            var model = this.viewModelFactory.CreateNavigationViewModel(username, isAuthenticated, isAdmin);
            return this.PartialView("Navigation", model);
        }
    }
}
