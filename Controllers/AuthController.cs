using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi_01.Dto;
using WebApi_01.Entities;
using WebApi_01.Intefaces;

namespace WebApi_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private User user;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;


        public AuthController(IUserRepository userRepository, IConfiguration configuration)
        {
            this._userRepository = userRepository;
            _configuration = configuration;
            user = new User();

        }

        [HttpPost , Route("register")]
        public IActionResult Register(UserDto request)
        {
            if (!_userRepository.UserExist(_userRepository.GetByName(request.Name).Id))
                return BadRequest("User not found");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            //user.Password = hashedPassword;
            //user.Name = request.Name;
            //_userRepository.CreateUser(user);

            return Ok(user.Name + "is registered");
        }

        [HttpPost , Route("login")]
        public ActionResult<User> Login(UserDto request)//!!! user does not get modified after registration action
        {
            if (!_userRepository.UserExist(request.Name))
                return BadRequest("User not found ");
            
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return BadRequest("Wrong password ");

            var u = _userRepository.GetByName(request.Name);
            string token = CreateToken(u);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name)
            };
            var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!)
                );
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims, 
                expires : DateTime.Now.AddDays(1),
                signingCredentials : creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
            
        }
    }
}
