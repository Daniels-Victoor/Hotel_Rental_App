using Staycation.Domain.Model;
using Staycation.Infrastructures.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staycation.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {

        readonly string _dataLocation = Path.Combine($"{new DirectoryInfo(".").Parent}", "Staycation.Infrastructures/DataStore");
        private List<UserModel> _allUsers = new List<UserModel>();

        private readonly IJsonHelper _jsonHelper;

        public UserRepository(IJsonHelper jsonHelper)
        {
            _jsonHelper = jsonHelper;
        }
        public List<UserModel> AllUser
        {
            get { return _allUsers; }
            set { _allUsers = value; }
        }
        public async Task<bool> Register(UserModel user)
        {
            try
            {
                var fileLocation = Path.Combine(_dataLocation, "UserFile.json");
                bool IsExisting;
                AllUser = await _jsonHelper.Reader<List<UserModel>>(fileLocation);
                if (AllUser == null)
                {
                    AllUser = new List<UserModel>();
                    IsExisting = true;
                }
                else
                {
                    IsExisting = AllUser.Where(x => x.Email == user.Email).Count() <= 0;
                }
                
                if (IsExisting)
                {
                    AllUser.Add(user);
                  await _jsonHelper.Writer(fileLocation, AllUser);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<UserModel> Login(string email, string password)
        {
            var fileLocation = Path.Combine(_dataLocation, "UserFile.json");
            AllUser = await _jsonHelper.Reader<List<UserModel>>(fileLocation);
            var user = AllUser.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
