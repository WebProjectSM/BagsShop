using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp.wwwroot
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckPasswordController : ControllerBase
    {
        readonly IUserBL _bl;
        public CheckPasswordController(IUserBL bl)
        {
            _bl = bl;
        }
        
       

        // POST api/<checkPasswordController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            {
                int pass_ok = _bl.Check_password(password);
                if (pass_ok != null)
                    return pass_ok;
                else
                    return StatusCode(404);
            }

        }

     
    }
}
