using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;
using System.Linq;

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

        public int VoteLog(int logId, string userId)
        {
            var userVoteOnLog = this.voteRepository
                .GetAll(v => v.LogId.Equals(logId) && v.UserId.Equals(userId))
                .FirstOrDefault();

            var userHasNotVoted = (userVoteOnLog == null);

            if (userHasNotVoted)
            {
                var log = this.logService.GetTrainingLogById(logId);

                if (log != null)
                {
                    var vote = this.voteFactory.CreateVote(logId, userId);

                    this.voteRepository.Add(vote);
                    this.unitOfWork.Commit();

                    return log.Votes.Count;
                }
            }

            return -1;
        }
    }
}
