using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Models.Entries;
using Logs.Web.Models.Logs;

namespace Logs.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IAuthenticationProvider authenticationProvider;

        public CommentController(ICommentService commentService, IAuthenticationProvider authenticationProvider)
        {
            if (commentService == null)
            {
                throw new ArgumentNullException(nameof(commentService));
            }

            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            this.commentService = commentService;
            this.authenticationProvider = authenticationProvider;
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Comment(NewCommentViewModel model)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            this.commentService.AddCommentToLog(model.Content, model.LogId, userId);

            return this.RedirectToAction("Details", "Logs", new { id = model.LogId, page = -1 });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CommentViewModel model)
        {
            this.commentService.EditComment(model.CommentId, model.Content);

            return this.PartialView("_CommentContentPartial", model);
        }
    }
}