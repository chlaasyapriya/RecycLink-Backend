using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public interface IUserRepo
    {
        public void AddUser(User user);
        public User GetUserByEmail(string email);
        public User GetUserById(int id);
        public Task<IEnumerable<User>> GetAllUsers();

    }
}
