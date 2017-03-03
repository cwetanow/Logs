using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;

namespace Logs.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IAuthenticationProvider provider;
        private readonly IUserService userService;

        public ProfileController(IAuthenticationProvider provider, IUserService userService)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (userService == null)
            {
                throw new ArgumentNullException("userService");
            }

            this.userService = userService;
            this.provider = provider;
        }

        [HttpGet]
        [Authorize]
        public RedirectToRouteResult MyLog()
        {
            var currentUserId = this.provider.CurrentUserId;
            var currentUser = this.userService.GetUserById(currentUserId);

            if (currentUser.Log != null)
            {
                return this.RedirectToAction("Details", "Logs", new { id = currentUser.Log.LogId });
            }

            return this.RedirectToAction("NoLog");
        }

        public ActionResult NoLog()
        {
            return this.View();
        }

        public ActionResult Details(string name)
        {
            return this.View();
        }
    }
}