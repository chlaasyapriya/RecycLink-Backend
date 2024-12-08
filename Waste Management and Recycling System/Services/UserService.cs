using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;

namespace Waste_Management_and_Recycling_System.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly string key;
        private readonly string issuer;
        private readonly string audience;
        public UserService(IUserRepo userRepo,IConfiguration iconfiguration)
        {
            _userRepo = userRepo;
            key = iconfiguration["JWT:Key"];
            issuer = iconfiguration["JWT:Issuer"];
            audience = iconfiguration["JWT:Audience"];
        }

        public bool RegisterUser(User user)
        {
            if(_userRepo.GetUserByEmail(user.Email)!=null)
                return false;
            user.PasswordHash=BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _userRepo.AddUser(user);
            return true;
        }
        public List<string> AuthenticateUser(string email, string password)
        {
            var user = _userRepo.GetUserByEmail(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;
            List<string> result = new List<string>();
            result.Add(GenerateToken(user.Username, user.Role, user.UserId));
            result.Add(user.UserId.ToString());
            return result;
        }
        public string GenerateToken(string username, string role, int userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var cred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Console.WriteLine("Service" + userId);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim("role", role),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            Console.WriteLine("Service2" + claims[1].Value);
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepo.GetAllUsers();
        }
    }
}
