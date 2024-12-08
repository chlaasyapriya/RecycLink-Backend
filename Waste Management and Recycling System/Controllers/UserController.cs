using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Services;

namespace Waste_Management_and_Recycling_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterData registerData)
        {
            User user = new User
            {
                Username = registerData.Username,
                PasswordHash = registerData.PasswordHash,
                Role = registerData.Role,
                Email = registerData.Email,
                PhoneNumber = registerData.PhoneNumber,
                Address = registerData.Address,
            };
            user.IsActive = true;
            user.Complaints = new List<Complaint>();
            user.Collections = new List<Collection>();
            user.EventsParticipated = new List<EventVolunteer>();
            if (_userService.RegisterUser(user))
                return Ok(user);
            return BadRequest("User already exists");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginData loginData)
        {
            var token = _userService.AuthenticateUser(loginData.Email, loginData.Password);
            if (token == null)
                return Unauthorized("Invalid Credentials");
            return Ok(token);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId) 
        { 
            var user=_userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpGet("allUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
    }

    public class RegisterData
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
    public class LoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
