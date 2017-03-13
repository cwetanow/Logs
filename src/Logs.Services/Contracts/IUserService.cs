using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface IUserService
    {
        User GetUserById(string id);

        User GetUserByUsername(string username);
    }
}