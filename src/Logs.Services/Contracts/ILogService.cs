using System;
using System.Collections.Generic;
using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface ILogService
    {
        TrainingLog GetTrainingLogById(int id);

        TrainingLog CreateTrainingLog(string name, string description, string userId);

        IEnumerable<TrainingLog> GetAllSortedByDate();

        IEnumerable<TrainingLog> GetLatestLogs(int count);

        IEnumerable<TrainingLog> GetTopLogs(int count);

        void AddEntryToLog(int logId, LogEntry entry, string userId);

        void AddCommentToLog(int logId, Comment comment);

        void EditLog(int logId, string newDescription, string newName);

        IEnumerable<TrainingLog> GetAll();

        void DeleteLog(int id);

        IEnumerable<TrainingLog> Search(string searchTerm);
    }
}
