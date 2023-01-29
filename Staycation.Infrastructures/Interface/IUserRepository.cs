using Staycation.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Staycation.Infrastructures.Interface
{
    public interface IUserRepository
    {
        List<UserModel> AllUser { get; set; }

        Task<UserModel> Login(string email, string password);
        Task<bool> Register(UserModel user);
    }
}