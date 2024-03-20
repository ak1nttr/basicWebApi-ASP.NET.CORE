using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_01.Dto;
using WebApi_01.Entities;
using WebApi_01.Intefaces;

namespace WebApi_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;   
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet , Authorize]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User),200)]
        public IActionResult GetUserById(long id) 
        {
            if (!_userRepository.UserExist(id))
                return NotFound();

            var user = _userRepository.GetById(id);
            if (!ModelState.IsValid)
            {
                
                return BadRequest(ModelState);
            }

            return Ok(user);

        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            var u = _userRepository.CreateUser(user);
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            return Ok(u.Name);
        }


        
    }
}
