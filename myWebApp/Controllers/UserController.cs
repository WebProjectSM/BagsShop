using AutoMapper;
using BusinessLayer;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp.Controllers.wwwroot
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserBL _bl;
        public readonly ILogger<UserController> _logger;
        readonly IMapper _mapper;
        public UserController(IUserBL bl,ILogger<UserController> logger,IMapper mapper)
        {
            _bl = bl;
            _logger =logger;
            _mapper = mapper;
        }


        // GET: api/<HomeController>
        [HttpGet]
        public async Task<ActionResult<UserDTO>> Get([FromQuery] string password, string name)
        {
           
          // _logger.LogInformation($"the user is {name}");

          //User user = await _bl.getUser(password, name);
          //  if (user != null)
          //  {
          //      return Ok(user);
            
          //  }
          //  _logger.LogError("erro");
          //  return StatusCode(204);
            
            User user = await _bl.getUser(password,name);
            UserDTO UserDTO = _mapper.Map<User, UserDTO>(user);

            return Ok(UserDTO);

        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
           
            User user =await _bl.getUserById(id);
            UserDTO userdto = _mapper.Map<User, UserDTO>(user);       
        
               
            if (userdto != null) 
                return userdto;
            return null;

        }

        // POST api/<HomeController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO userDto)
        {
            User user = _mapper.Map<UserDTO, User>(userDto);     
           User user1 = await _bl.addUser(user);
            //return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
             UserDTO userdto = _mapper.Map<User, UserDTO>(user);     
            if(userdto!=null)
                return Ok(userdto);
            else return StatusCode(204);

        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDTO userToUpdate)
        { 
            User user = _mapper.Map<UserDTO, User>(userToUpdate); 
            _bl.update(id, user);



        }
       
      

        // DELETE api/<HomeController>/50
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
