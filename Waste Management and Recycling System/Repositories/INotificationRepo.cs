using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public interface INotificationRepo
    {
        public Task AddNotification(Notification notification);
        public Task<List<Notification>> GetNotificationsByUserId(int userId);

    }
}
