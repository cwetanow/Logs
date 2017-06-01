using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using System;
using System.Web.Mvc;

namespace Logs.Web.Areas.Users.Controllers
{
    public class NutritionController : Controller
    {
        private readonly IUserService userService;
        private readonly IViewModelFactory viewModelFactory;

        public NutritionController(IUserService userService, IViewModelFactory viewModelFactory)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.userService = userService;
            this.viewModelFactory = viewModelFactory;
        }

        public ActionResult Details(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return new HttpNotFoundResult();
            }

            var user = this.userService.GetUserByUsername(username);

            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            var model = this.viewModelFactory.CreateUserIdViewModel(user.Id);

            return this.View(model);
        }
    }
}