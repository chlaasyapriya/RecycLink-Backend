using System.ComponentModel.DataAnnotations;

namespace Waste_Management_and_Recycling_System.Models
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }
        public int UserId { get; set; }
        public ICollection<EventVolunteer> EventsParticipated { get; set; }
        public int TotalHoursWorked { get; set; }

        public User User { get; set; }
    }
}
