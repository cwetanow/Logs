using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;

namespace Logs.Services
{
    public class VoteService : IVoteService
    {
        private readonly IRepository<Vote> voteRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IVoteFactory voteFactory;
        private readonly ILogService logService;

        public VoteService(IRepository<Vote> voteRepository, IUnitOfWork unitOfWork, ILogService logService, IVoteFactory voteFactory)
        {
            // TODO: Null checks
            this.voteRepository = voteRepository;
            this.unitOfWork = unitOfWork;
            this.logService = logService;
            this.voteFactory = voteFactory;
        }

        public bool VoteLog(int logId, string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
