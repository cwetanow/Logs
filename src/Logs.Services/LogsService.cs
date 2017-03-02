using System;
using System.Collections.Generic;
using System.Linq;
using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Services.Contracts;

namespace Logs.Services
{
    public class LogsService : ILogService
    {
        private readonly IRepository<TrainingLog> logRepository;
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITrainingLogFactory logFactory;

        public LogsService(IRepository<TrainingLog> logRepository,
            IUnitOfWork unitOfWork,
            ITrainingLogFactory logFactory,
            IUserService userService)
        {
            if (logRepository == null)
            {
                throw new ArgumentNullException("logRepository");
            }

            if (logFactory == null)
            {
                throw new ArgumentNullException("logFactory");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            if (userService == null)
            {
                throw new ArgumentNullException("userService");
            }

            this.logRepository = logRepository;
            this.userService = userService;
            this.logFactory = logFactory;
            this.unitOfWork = unitOfWork;
        }

        public TrainingLog GetTrainingLogById(int id)
        {
            return this.logRepository.GetById(id);
        }

        public TrainingLog CreateTrainingLog(string name, string description, string userId)
        {
            var user = this.userService.GetUserById(userId);
            var log = this.logFactory.CreateTrainingLog(name, description, DateTime.Now, user);

            this.logRepository.Add(log);
            this.unitOfWork.Commit();

            return log;
        }

        public IEnumerable<TrainingLog> GetLogs()
        {
            return this.logRepository.GetAll();
        }

        public IEnumerable<TrainingLog> GetPaged(int page, int count)
        {
            // FIX
            return this.logRepository.GetPaged(null, (TrainingLog l) => l.LastEntry, page, count, true);
        }

        public IEnumerable<TrainingLog> GetLatestLogs(int count)
        {
            return this.logRepository.GetPaged(null, (TrainingLog t) => t.DateCreated, 1, count, true);
        }

        public IEnumerable<TrainingLog> GetTopLogs(int count)
        {
            return this.logRepository.GetPaged(null, (TrainingLog t) => t.Votes.Count, 1, count);
        }
    }
}
