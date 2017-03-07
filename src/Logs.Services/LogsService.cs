using System;
using System.Collections.Generic;
using System.Linq;
using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;

namespace Logs.Services
{
    public class LogsService : ILogService
    {
        private readonly IRepository<TrainingLog> logRepository;
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;
        private readonly ITrainingLogFactory logFactory;
        private readonly IDateTimeProvider provider;

        public LogsService(IRepository<TrainingLog> logRepository,
            IUnitOfWork unitOfWork,
            ITrainingLogFactory logFactory,
            IUserService userService,
            IDateTimeProvider provider)
        {
            if (logRepository == null)
            {
                throw new ArgumentNullException(nameof(logRepository));
            }

            if (logFactory == null)
            {
                throw new ArgumentNullException(nameof(logFactory));
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            this.provider = provider;
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

            var currentTime = this.provider.GetCurrenTime();
            var log = this.logFactory.CreateTrainingLog(name, description, currentTime, user);

            this.logRepository.Add(log);
            this.unitOfWork.Commit();

            return log;
        }

        public IEnumerable<TrainingLog> GetAllSortedByDate()
        {
            return this.logRepository.GetAll((TrainingLog l) => true, (TrainingLog l) => l.DateCreated, true);
        }

        public IEnumerable<TrainingLog> GetLatestLogs(int count)
        {
            return this.logRepository.GetPaged(null, (TrainingLog t) => t.DateCreated, 1, count, true);
        }

        public IEnumerable<TrainingLog> GetTopLogs(int count)
        {
            return this.logRepository.GetPaged(null, (TrainingLog t) => t.Votes.Count, 1, count);
        }

        public void AddEntryToLog(int logId, LogEntry entry, string userId)
        {
            var log = this.logRepository.GetById(logId);

            if (log != null && log.User.Id == userId)
            {
                log.Entries.Add(entry);
                log.LastEntryDate = entry.EntryDate;
                log.LastEntry = entry;
                log.LastActivityUser = log.User.Name;

                this.unitOfWork.Commit();
            }
        }

        public void AddCommentToLog(int logId, Comment comment)
        {
            var log = this.logRepository.GetById(logId);

            if (log != null)
            {
                log.LastEntry.Comments.Add(comment);
                log.LastEntryDate = comment.Date;
                log.LastActivityUser = comment.User.Name;

                this.unitOfWork.Commit();
            }
        }
    }
}
