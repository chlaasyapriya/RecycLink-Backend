using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public class NotificationRepo: INotificationRepo
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public NotificationRepo(WasteManagementandRecyclingDbContext context)
        {
             _context = context;
        }
        public async Task AddNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Notification>> GetNotificationsByUserId(int userId)
        {
            return await _context.Notifications.Where(n => n.UserId == userId).OrderByDescending(n => n.Timestamp).ToListAsync();
        }
    }
}
