using API.Helpers;
using API.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserModule.Model.Dto;
using UserModule.Service.IService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUserService userService;
        private readonly AppSettings appSettings;
        private readonly ITokenService tokenService;

        public LoginController(IUserService service, IOptions<AppSettings>  settings, ITokenService token)
        {
            userService = service;
            appSettings = settings.Value;
            tokenService = token;

        }


        /// <summary>
        /// Logowanie do systemu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Logowanie sie udało, JWT umieszczony w cookie</response>
        /// <response code="400">Logowanie sie nie udało</response>
        // POST api/<LoginController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Authenticate([FromBody] UserLoginDto model)
        {
            var usr = userService.AuthenticateAsync(model.UserName, model.Password);
            if (usr.Result != null)
            { 
                var token = tokenService.generateToken(usr.Result.Id);
                HttpContext.Response.Headers.Add("Bearer", token);
                return Ok(usr.Result);
            }
            return BadRequest(new { message = "Username or password is incorrect" });


        }
    }
}
