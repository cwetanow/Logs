using System;
using Logs.Data.Contracts;
using Logs.Factories;
using Logs.Models;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;

namespace Logs.Services
{
    public class EntryService : IEntryService
    {
        private readonly ILogService logService;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly ILogEntryFactory logEntryFactoryfactory;
        private readonly IRepository<LogEntry> entryRepository;
        private readonly IUnitOfWork unitOfWork;

        public EntryService(ILogService logService,
            IDateTimeProvider dateTimeProvider,
            ILogEntryFactory logEntryFactoryfactory,
            IRepository<LogEntry> entryRepository,
            IUnitOfWork unitOfWork)
        {
            if (logService == null)
            {
                throw new ArgumentNullException(nameof(logService));
            }

            if (dateTimeProvider == null)
            {
                throw new ArgumentNullException(nameof(dateTimeProvider));
            }

            if (logEntryFactoryfactory == null)
            {
                throw new ArgumentNullException(nameof(logEntryFactoryfactory));
            }

            this.logService = logService;
            this.logEntryFactoryfactory = logEntryFactoryfactory;
            this.dateTimeProvider = dateTimeProvider;

            this.entryRepository = entryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddEntryToLog(string content, int logId, string userId)
        {
            var currentDate = this.dateTimeProvider.GetCurrenTime();

            var entry = this.logEntryFactoryfactory.CreateLogEntry(content, currentDate);

            this.logService.AddEntryToLog(logId, entry, userId);
        }

        public void EditEntry(int entryId, string newContent)
        {
            var entry = this.entryRepository.GetById(entryId);

            if (entry != null)
            {
                entry.Content = newContent;

                this.entryRepository.Update(entry);
                this.unitOfWork.Commit();
            }
        }
    }
}
