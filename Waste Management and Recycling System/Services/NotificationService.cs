using SendGrid;
using SendGrid.Helpers.Mail;
using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;

namespace Waste_Management_and_Recycling_System.Services
{
    public class NotificationService: INotificationService
    {
        private readonly INotificationRepo _notificationRepo;
        private readonly string _apiKey;
        private readonly string _senderEmail;
        private readonly string _senderName;
        public NotificationService(INotificationRepo notificationRepo, IConfiguration iconfiguration)
        {
            _notificationRepo = notificationRepo;
            _apiKey = iconfiguration["SendGrid:ApiKey"];
            _senderEmail = iconfiguration["SendGrid:SenderEmail"];
            _senderName = iconfiguration["SendGrid:SenderName"];
        }
        public async Task SendEmailNotification(int userId, string receiverEmail, string receiverName, string subject, string messageBody, string notificationType)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_senderEmail, _senderName);
            var to = new EmailAddress(receiverEmail, receiverName);
            var plainTextContent = $"Hi {receiverName},\n{messageBody}";
            var htmlContent = $"<p>Hi {receiverName},</p><p>{messageBody}</p>";
            var message = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(message);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to send email notification.");

            var notification = new Notification
            {
                UserId = userId,
                Message = messageBody,
                Type = notificationType,
                Timestamp = DateTime.UtcNow,
                Status = "Sent"
            };

            await _notificationRepo.AddNotification(notification);
        }
        public async Task SendNotification(int userId, string receiverEmail, string receiverName, string subject, string messageBody, string notificationType)
        {
            var notification = new Notification
            {
                UserId = userId,
                Message = messageBody,
                Type = notificationType,
                Timestamp = DateTime.UtcNow,
                Status = "Sent",
            };
            await _notificationRepo.AddNotification(notification);
        }

        public async Task<List<Notification>> GetNotificationsByUserId(int userId)
        {
            return await _notificationRepo.GetNotificationsByUserId(userId);
        }

    }
}
