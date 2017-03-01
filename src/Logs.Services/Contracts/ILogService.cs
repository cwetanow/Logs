using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface ILogService
    {
        TrainingLog GeTrainingLogById(int id);
    }
}
