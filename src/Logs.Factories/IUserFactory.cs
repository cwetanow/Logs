using Logs.Models;

namespace Logs.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string username, string email);
    }
}
