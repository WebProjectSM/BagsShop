using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp.wwwroot
{
    [Route("api/[controller]")]
    [ApiController]
    public class checkPasswordController : ControllerBase
    {
        readonly IUserBL _bl;
        public checkPasswordController(IUserBL bl)
        {
            _bl = bl;
        }
        // GET: api/<checkPasswordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<checkPasswordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<checkPasswordController>
        [HttpPost]
        //public ActionResult<int> Post([FromBody] string password)
        //{
        //    {
        //        var pass_ok = _bl.Check_password(password);
        //        if (pass_ok != null)
        //            return pass_ok;
        //        else
        //            return StatusCode(404);
        //    }

        //}

        // PUT api/<checkPasswordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<checkPasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
