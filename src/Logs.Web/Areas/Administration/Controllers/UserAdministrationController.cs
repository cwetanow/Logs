using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Models;
using PagedList;

namespace Logs.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = AdministratorRoleName)]
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

        public ActionResult Index(int page = 1, int count = 10)
        {
            // TODO: Intercept
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

        // GET: Administration/UserAdministration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/UserAdministration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/UserAdministration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/UserAdministration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
