using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public class UserRepo: IUserRepo
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public UserRepo(WasteManagementandRecyclingDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User GetUserByEmail(string email)
        {
            var user= _context.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }
        public User GetUserById(int id)
        {
            var user=_context.Users.FirstOrDefault(u=>u.UserId == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users=await _context.Users.ToListAsync();
            return users;
        }

    }
}
