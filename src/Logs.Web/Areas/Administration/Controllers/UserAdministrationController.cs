using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace Logs.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = AdministratorRoleName)]
    public class UserAdministrationController : Controller
    {
        private const string AdministratorRoleName = "administrator";

        private readonly IUserService userService;

        public UserAdministrationController(IUserService userService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            this.userService = userService;
        }

        public ActionResult Index(int page = 1, int count = 10)
        {
            // TODO: Intercept
            var users = this.userService.GetUsers();

            var model = new List<UserViewModel>();
            foreach (var user in users)
            {
                // TODO: Check if admin
                var viewModel = new UserViewModel(user, true);
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
