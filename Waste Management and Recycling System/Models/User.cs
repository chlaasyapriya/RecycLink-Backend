using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Waste_Management_and_Recycling_System.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public ICollection<Collection> Collections { get; set; }
        [JsonIgnore]
        public ICollection<Complaint> Complaints { get; set; }
        [JsonIgnore]
        public ICollection<EventVolunteer> EventsParticipated { get; set; }
    }
}
