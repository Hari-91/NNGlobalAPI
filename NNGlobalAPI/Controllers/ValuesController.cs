using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ILogger log4console;

        public ValuesController(ILogger<ValuesController> logger)
        {
            log4console = logger;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
           var ret =new string[] { "value1", "value2" };
            //log4console.LogDebug("DEBUG: użytkownik pobrał dane z kontrolera!");
            //log4console.LogInformation("INFO: użytkowNik pobrał dane z kontrolera!");
            //log4console.LogError("ERROR: użytkownik pobrał dane z kontrolera!");
            //log4console.LogWarning("WARNING: użytkownik pobrał dane z kontrolera!");
            return ret;

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
