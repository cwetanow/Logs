using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Infrastructure.Factories;
using Logs.Web.Models.Upload;

namespace Logs.Web.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly ICloudinaryFactory cloudinaryFactory;
        private readonly IViewModelFactory viewModelFactory;

        public UploadController(IUserService userService,
             IAuthenticationProvider authenticationProvider,
             ICloudinaryFactory cloudinaryFactory,
             IViewModelFactory viewModelFactory
             )
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            if (cloudinaryFactory == null)
            {
                throw new ArgumentNullException(nameof(cloudinaryFactory));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            this.userService = userService;
            this.authenticationProvider = authenticationProvider;
            this.cloudinaryFactory = cloudinaryFactory;
            this.viewModelFactory = viewModelFactory;
        }

        public ActionResult Index()
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var user = this.userService.GetUserById(userId);

            var cloudinary = this.cloudinaryFactory.GetCloudinary();

            var model = this.viewModelFactory.CreateUploadViewModel(cloudinary, user.ProfileImageUrl);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Index(UploadViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.authenticationProvider.CurrentUserId;

                this.userService.ChangeProfilePicture(userId, model.ImageUrl);
            }

            model.Cloudinary = this.cloudinaryFactory.GetCloudinary();

            return this.View(model);
        }
    }
}