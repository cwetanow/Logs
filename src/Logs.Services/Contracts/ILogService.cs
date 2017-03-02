using System;
using System.Collections.Generic;
using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface ILogService
    {
        TrainingLog GetTrainingLogById(int id);

        TrainingLog CreateTrainingLog(string name, string description, string userId);

        IEnumerable<TrainingLog> GetLogs();

        IEnumerable<TrainingLog> GetPaged(int page, int count);

        IEnumerable<TrainingLog> GetLatestLogs(int count);

        IEnumerable<TrainingLog> GetTopLogs(int count);
    }
}
