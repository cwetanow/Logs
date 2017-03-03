using System;
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
        private readonly ILogEntryFactory factory;
        private readonly IUserService userService;

        public EntryService(ILogService logService,
            IDateTimeProvider dateTimeProvider,
            ILogEntryFactory factory,
            IUserService userService)
        {
            if (logService == null)
            {
                throw new ArgumentNullException("logService");
            }

            if (userService == null)
            {
                throw new ArgumentNullException("userService");
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
            this.userService = userService;
        }

        public void AddEntryToLog(string content, int logId)
        {
            var currentDate = this.dateTimeProvider.GetCurrenTime();

            var entry = this.factory.CreateLogEntry(content, currentDate);

            this.logService.AddEntryToLog(logId, entry);
        }

        public void AddCommentToLog(string content, int logId, string userId)
        {
            var currentDate = this.dateTimeProvider.GetCurrenTime();

            var user = this.userService.GetUserById(userId);

            var comment = new Comment { Content = content, Date = currentDate, User = user };

            this.logService.AddCommentToLog(logId, comment);
        }
    }
}
