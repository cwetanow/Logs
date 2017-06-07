using System;
using System.Threading.Tasks;

namespace Logs.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAsync();
    }
}
