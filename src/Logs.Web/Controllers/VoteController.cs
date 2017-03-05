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
            this.voteService = voteService;
            this.authenticationProvider = authenticationProvider;
        }
        
        [Authorize]
        public ActionResult Vote(int logId)
        {
            var currentUserId = this.authenticationProvider.CurrentUserId;

            this.voteService.VoteLog(logId, currentUserId);

            return this.RedirectToAction("Details", "Logs", new { id = logId });
        }
    }
}