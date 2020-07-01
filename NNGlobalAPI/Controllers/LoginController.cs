
using AutoMapper;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UserModule.Model;
using UserModule.Model.Dto;
using UserModule.Model.RawModel;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDbContext userDbContext;
        //private readonly IAccessTokenService accessTokenService;
        //private readonly IUserLoginManager userLoginManager;
        private readonly UserManager<User> userManager;
        //private readonly IMapper mapper;
        //private readonly IConfiguration configuration;
        //private readonly IMediator mediator;
        private readonly SignInManager<User> signInManager;
        //private readonly NovatekNetworkDbContext novatekNetworkDb;


        //public LoginController(IAccessTokenService accessTokenService,
        //                         IUserLoginManager userLoginManager,
        //                         IMapper mapper,
        //                         IConfiguration configuration,
        //                         IMediator mediator,
        //                         SignInManager<User> signInManager,
        //                         NovatekNetworkDbContext novatekNetworkDbContext)
        //{
        //    this.mediator = mediator;
        //    this.accessTokenService = accessTokenService;
        //    this.userLoginManager = userLoginManager;
        //this.mapper = mapper;
        //this.configuration = configuration;
        //this.signInManager = signInManager;
        //novatekNetworkDb = novatekNetworkDbContext;
        //}
        public LoginController(UserDbContext context, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            userDbContext = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto model)
        {
            User usr = await userManager.FindByNameAsync(model.UserName);
            var pass = await userManager.CheckPasswordAsync(usr, model.Password);

            if (pass)
            {

                return Ok(usr);
            }
            return BadRequest(new { message = "Username or password is incorrect" });

           
        }

 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
