namespace Waste_Management_and_Recycling_System.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; } 
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; }
    }
}
