using Staycation.Domain.Model;
using System.Threading.Tasks;

namespace Staycation.Core.Interface
{
    public interface IUserServices
    {
        Task<UserModel> Login(string email, string password);
        Task<UserModel> RegisterUser(string email, string password, string firstName, string lastName);
    }
}