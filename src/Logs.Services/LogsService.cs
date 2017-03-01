using Logs.Data.Contracts;
using Logs.Models;
using Logs.Services.Contracts;

namespace Logs.Services
{
    public class LogsService : ILogService
    {
        private readonly IRepository<TrainingLog> logRepository;
        private readonly IUnitOfWork unitOfWork;

        public LogsService(IRepository<TrainingLog> logRepository, IUnitOfWork unitOfWork)
        {
            this.logRepository = logRepository;
            this.unitOfWork = unitOfWork;
        }

        public TrainingLog GeTrainingLogById(int id)
        {
            return this.logRepository.GetById(id);
        }
    }
}
