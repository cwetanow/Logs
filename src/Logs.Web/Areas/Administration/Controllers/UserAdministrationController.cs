using System;
using System.Web.Mvc;
using Logs.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace Logs.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "administrator")]
    public class UserAdministrationController : Controller
    {
        private readonly IUserService userService;

        public UserAdministrationController(IUserService userService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            this.userService = userService;
        }

        public ActionResult Index()
        {
            return this.View();
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
