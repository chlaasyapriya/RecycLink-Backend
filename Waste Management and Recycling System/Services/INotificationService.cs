using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Services
{
    public interface INotificationService
    {
        public Task SendEmailNotification(int userId, string receiverEmail, string receiverName, string subject, string messageBody, string notificationType);
        public Task SendNotification(int userId, string receiverEmail, string receiverName, string subject, string messageBody, string notificationType);
        public Task<List<Notification>> GetNotificationsByUserId(int userId);
    }
}
