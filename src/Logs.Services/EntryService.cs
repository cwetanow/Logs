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
        private readonly ILogEntryFactory logEntryFactoryfactory;
        private readonly ICommentFactory commentFactory;
        private readonly IUserService userService;

        public EntryService(ILogService logService,
            IDateTimeProvider dateTimeProvider,
            ILogEntryFactory logEntryFactoryfactory,
            IUserService userService,
            ICommentFactory commentFactory)
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

            if (logEntryFactoryfactory == null)
            {
                throw new ArgumentNullException("logEntryFactoryfactory");
            }

            if (commentFactory == null)
            {
                throw new ArgumentNullException("commentFactory");
            }

            this.logService = logService;
            this.logEntryFactoryfactory = logEntryFactoryfactory;
            this.dateTimeProvider = dateTimeProvider;
            this.userService = userService;
            this.commentFactory = commentFactory;
        }

        public void AddEntryToLog(string content, int logId, string userId)
        {
            var currentDate = this.dateTimeProvider.GetCurrenTime();

            var entry = this.logEntryFactoryfactory.CreateLogEntry(content, currentDate);

            this.logService.AddEntryToLog(logId, entry, userId);
        }

        public void AddCommentToLog(string content, int logId, string userId)
        {
            var currentDate = this.dateTimeProvider.GetCurrenTime();

            var user = this.userService.GetUserById(userId);

            var comment = this.commentFactory.CreateComment(content, currentDate, user);

            this.logService.AddCommentToLog(logId, comment);
        }
    }
}
