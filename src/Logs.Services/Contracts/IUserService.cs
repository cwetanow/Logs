using System.Collections.Generic;
using Logs.Models;
using Logs.Models.Enumerations;

namespace Logs.Services.Contracts
{
    public interface IUserService
    {
        User GetUserById(string id);

        User GetUserByUsername(string username);

        void EditUser(string userId, string description, int age, double weight, int height, double bodyFat, GenderType genderType);

        void ChangeProfilePicture(string userId, string newUrl);

        IEnumerable<User> GetUsers();
    }
}