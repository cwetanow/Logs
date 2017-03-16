using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Models;
using PagedList;

namespace Logs.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "administrator")]
    public class UserAdministrationController : Controller
    {
        private const string AdministratorRoleName = "administrator";

        private readonly IUserService userService;
        private readonly IAuthenticationProvider authenticationProvider;

        public UserAdministrationController(IUserService userService, IAuthenticationProvider authenticationProvider)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            this.userService = userService;
            this.authenticationProvider = authenticationProvider;
        }

        //[OutputCache(VaryByParam = "page", Duration = 60 * 10)]
        public ActionResult Index(int page = 1, int count = 10)
        {
            var users = this.userService.GetUsers();

            var model = new List<UserViewModel>();
            foreach (var user in users)
            {
                var isAdmin = this.authenticationProvider.IsInRole(user.Id, AdministratorRoleName);
                var viewModel = new UserViewModel(user, isAdmin);
                model.Add(viewModel);
            }

            return this.View(model.ToPagedList(page, count));
        }

        public ActionResult Ban(string userId, int page)
        {
            return this.RedirectToAction("Index", new { page = page });
        }

        public ActionResult RemoveAdmin(string userId, int page)
        {
            this.authenticationProvider.RemoveFromRole(userId, AdministratorRoleName);

            return this.RedirectToAction("Index", new { page = page });
        }

        public ActionResult AddAdmin(string userId, int page)
        {
            this.authenticationProvider.AddToRole(userId, AdministratorRoleName);

            return this.RedirectToAction("Index", new { page = page });
        }
    }
}
