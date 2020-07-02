using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserModule.Model.RawModel;

namespace UserModule.Service.IService
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
        IEnumerable<User> GetAll(List<User> usersList);
        bool ValidateUserDataAccess(int id, HttpRequest request);
    }
}
