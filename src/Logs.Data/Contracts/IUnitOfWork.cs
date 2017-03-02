using System;

namespace Logs.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
