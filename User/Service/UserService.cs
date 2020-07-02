using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using UserModule.Model.RawModel;
using UserModule.Service.IService;

namespace UserModule.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;


        public UserService(UserManager<User> manager)
        {
            userManager = manager;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);
            var pass = await userManager.CheckPasswordAsync(user, password);
            return user == null ? null : (pass ? user : null);
        }




        public bool ValidateUserDataAccess(int id, HttpRequest request)
        {
            var jwtToken = request.Headers["Authorization"].ToString().Split(" ")[1];
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);
            var tokenId = int.Parse(token.Claims.First(c => c.Type == "unique_name").Value);
            return tokenId == id;
        }


        IEnumerable<User> IUserService.GetAll(List<User> usersList)
        {
            throw new NotImplementedException();
        }
    }
}
