using System;
using Logs.Factories;
using Logs.Providers.Contracts;
using Logs.Services.Contracts;

namespace Logs.Services
{
    public class EntryService : IEntryService
    {
        private readonly ILogService logService;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly ILogEntryFactory factory;

        public EntryService(ILogService logService, IDateTimeProvider dateTimeProvider, ILogEntryFactory factory)
        {
            if (logService == null)
            {
                throw new ArgumentNullException("logService");
            }

            if (dateTimeProvider == null)
            {
                throw new ArgumentNullException("dateTimeProvider");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            this.logService = logService;
            this.factory = factory;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void AddEntryToLog(string content, int logId)
        {
            var currentDate = this.dateTimeProvider.GetCurrenTime();

            var entry = this.factory.CreateLogEntry(content, currentDate);

            this.logService.AddEntryToLog(logId, entry);
        }
    }
}
