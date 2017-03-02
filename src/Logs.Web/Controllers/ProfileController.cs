﻿using System;
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

        //public ActionResult Index(string name)
        //{
        //    // TODO
        //    return View("~/Views/Home/Index");
        //}

        [HttpGet]
        public RedirectToRouteResult MyLog()
        {
            var currentUserId = this.provider.CurrentUserId;
            var currentUser = this.userService.GetUserById(currentUserId);

            return this.RedirectToAction("Details", "Logs", new { id = currentUser.Log.LogId });
        }
    }
}