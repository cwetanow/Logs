using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface IUserService
    {
        User GetUserById(string id);

      //  User GetUserByName(string name);
    }
}