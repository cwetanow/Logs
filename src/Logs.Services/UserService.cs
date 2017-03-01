﻿using System;
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
                throw new ArgumentNullException("userRepository");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public User GetUserById(string id)
        {
            return this.userRepository.GetById(id);
        }
    }
}
