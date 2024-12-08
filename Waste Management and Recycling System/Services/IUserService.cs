using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Services
{
    public interface IUserService
    {
        public bool RegisterUser(User user);
        public List<string> AuthenticateUser(string email, string password);
        public User GetUserById(int id);
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
