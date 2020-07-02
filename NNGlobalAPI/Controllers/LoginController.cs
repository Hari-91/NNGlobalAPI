using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserModule.Model.Dto;
using UserModule.Service.IService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUserService userService;

        public LoginController(IUserService service)
        {
            userService = service;
        }


        /// <summary>
        /// Logowanie do systemu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // POST api/<LoginController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Authenticate([FromBody] UserLoginDto model)
        {
            var usr = userService.AuthenticateAsync(model.UserName, model.Password);
            if (usr.Result != null)
            {
                return Ok(usr.Result);
            }
            return BadRequest(new { message = "Username or password is incorrect" });


        }
    }
}
