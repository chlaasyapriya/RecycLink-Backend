namespace Waste_Management_and_Recycling_System.Models
{
    public class EventVolunteer
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int VolunteerId { get; set; }
        public User Volunteer { get; set; }
        public bool HasParticipated { get; set; }
    }
}
