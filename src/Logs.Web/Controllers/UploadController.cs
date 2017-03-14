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

        public UploadController(IUserService userService,
            IAuthenticationProvider authenticationProvider,
            ICloudinaryFactory cloudinaryFactory
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

            this.userService = userService;
            this.authenticationProvider = authenticationProvider;
            this.cloudinaryFactory = cloudinaryFactory;
        }

        public ActionResult Index()
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var user = this.userService.GetUserById(userId);

            var cloudinary = this.cloudinaryFactory.GetCloudinary();

            var model = new UploadViewModel(cloudinary, user.ProfileImageUrl);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Index(UploadViewModel model)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            this.userService.ChangeProfilePicture(userId, model.ImageUrl);

            return this.View(model);
        }
    }
}