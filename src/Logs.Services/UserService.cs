using System;
using System.Linq;
using Logs.Data.Contracts;
using Logs.Models;
using Logs.Services.Contracts;

namespace Logs.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<User> userRepository,
            IUnitOfWork unitOfWork)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException(nameof(userRepository));
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public User GetUserById(string id)
        {
            return this.userRepository.GetById(id);
        }

        public User GetUserByUsername(string username)
        {
            var user = this.userRepository
                .GetAll(u => u.UserName.Equals(username))
                .FirstOrDefault();

            return user;
        }

        public void EditUser(string userId, string description, int age, double weight, int height, double bodyFat)
        {
            var user = this.userRepository.GetById(userId);

            if (user != null)
            {
                user.Description = description;
                user.Age = age;
                user.Weight = weight;
                user.Height = height;
                user.BodyFatPercent = bodyFat;

                this.userRepository.Update(user);
                this.unitOfWork.Commit();
            }
        }
    }
}
