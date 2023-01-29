using Staycation.Core.Interface;
using Staycation.Domain.Model;
using Staycation.Infrastructures.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Staycation.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;
        public UserServices(IUserRepository productRepo)
        {
            _repository = productRepo;
        }
        public async Task<UserModel> RegisterUser(string email, string password, string firstName, string lastName)
        {
            UserModel newUser = new UserModel(email, EasyEncryption.SHA.ComputeSHA256Hash(password), firstName, lastName);
            bool IsRegistered = await _repository.Register(newUser);
            if (IsRegistered)
            {
                return newUser;
            }
            return null;
        }
        public async Task<UserModel> Login(string email, string password)
        {
            var result = await _repository.Login(email, EasyEncryption.SHA.ComputeSHA256Hash(password));
            return result;
        }
    }
}
