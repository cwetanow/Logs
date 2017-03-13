using Logs.Models;

namespace Logs.Services.Contracts
{
    public interface IUserService
    {
        User GetUserById(string id);

        User GetUserByUsername(string username);

        void EditUser(string userId, string description, int age, double weight, int height, double bodyFat);
    }
}