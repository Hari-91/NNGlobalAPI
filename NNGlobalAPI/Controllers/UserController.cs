using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserModule.Model;
using UserModule.Model.RawModel;

namespace API.Controllers
{


    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext userDbContext;

        public UserController(UserDbContext userDb)
        {
            userDbContext = userDb;
        }
        // GET: api/<UserController>
        [HttpGet]
        public Task<List<JoinUserModule>> Get()
        {

            var usr = userDbContext.USER_MODULE
                .AsNoTracking()
                .Where(m => m.ID_USER == 13890)
                .Include(m=>m.Module)
                    .ThenInclude(f=>f.Funcionality)
                .ToListAsync();
               

            return usr;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
