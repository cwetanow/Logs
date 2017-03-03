using System;
using Logs.Data.Contracts;
using Logs.Models;
using Logs.Services.Contracts;

namespace Logs.Services
{
    public class EntryService : IEntryService
    {
        private readonly IRepository<LogEntry> entryRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogService logService;

        public EntryService(IRepository<LogEntry> entryRepository,
            IUnitOfWork unitOfWork, ILogService logService)
        {
            if (entryRepository == null)
            {
                throw new ArgumentNullException("entryRepository");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            this.entryRepository = entryRepository;
            this.unitOfWork = unitOfWork;
            this.logService = logService;
        }

        public LogEntry CreateNewEntry(string content, int logId)
        {
            var entry = new LogEntry { Content = content, LogId = logId, EntryDate = DateTime.Now };

            var log = this.logService.GetTrainingLogById(logId);
            log?.Entries.Add(entry);

            this.entryRepository.Add(entry);
            this.unitOfWork.Commit();

            return entry;
        }
    }
}
