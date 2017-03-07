using System;
using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;

namespace Logs.Web.Controllers
{
    public class VoteController : Controller
    {
        private readonly IVoteService voteService;
        private readonly IAuthenticationProvider authenticationProvider;

        public VoteController(IVoteService voteService, IAuthenticationProvider authenticationProvider)
        {
            if (voteService == null)
            {
                throw new ArgumentNullException(nameof(voteService));
            }

            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            this.voteService = voteService;
            this.authenticationProvider = authenticationProvider;
        }

        [Authorize]
        [HttpPost]
        public ActionResult Vote(int logId, int currentVoteCount)
        {
            var currentUserId = this.authenticationProvider.CurrentUserId;

            var rating = this.voteService.VoteLog(logId, currentUserId);

            if (rating < 0)
            {
                rating = currentVoteCount;
            }

            return this.PartialView(rating);
        }
    }
}