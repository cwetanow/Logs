﻿using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Common;
using Logs.Models;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Profile;

namespace Logs.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IAuthenticationProvider provider;
        private readonly IUserService userService;
        private readonly IViewModelFactory viewModelFactory;

        public ProfileController(IAuthenticationProvider provider, IUserService userService, IViewModelFactory viewModelFactory)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.userService = userService;
            this.provider = provider;
            this.viewModelFactory = viewModelFactory;
        }

        [HttpGet]
        [Authorize]
        public RedirectToRouteResult MyLog()
        {
            var currentUserId = this.provider.CurrentUserId;
            var currentUser = this.userService.GetUserById(currentUserId);

            if (currentUser.TrainingLog != null)
            {
                return this.RedirectToAction("Details", "Logs", new { id = currentUser.TrainingLog.LogId });
            }

            return this.RedirectToAction("NoLog");
        }

        public ActionResult NoLog()
        {
            return this.View();
        }

        public ActionResult Details(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            var currentUserId = this.provider.CurrentUserId;

            var canEdit = user.Id.Equals(currentUserId) || this.provider.IsInRole(currentUserId, Constants.AdministratorRoleName);

            var model = this.viewModelFactory.CreateUserProfileViewModel(user, canEdit);

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Edit(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.userService.EditUser(model.Id, model.Description, model.Age, model.Weight, model.Height, model.BodyFatPercent, model.GenderType);
            }

            return this.PartialView("_UserStatsPartial", model);
        }

        [Authorize]
        public ActionResult NewLog()
        {
            var currentUserId = this.provider.CurrentUserId;

            var currentUser = this.userService.GetUserById(currentUserId);

            if (currentUser.LogId == null)
            {
                return this.RedirectToAction("Create", "Logs");
            }

            var logId = currentUser.LogId;

            var model = this.viewModelFactory.CreateNewLogViewModel(logId.Value);

            return this.View(model);
        }
    }
}