using System.ComponentModel.DataAnnotations;

namespace Waste_Management_and_Recycling_System.Models
{
    public class Complaint
    {
        public int ComplaintId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string IssueType { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime DateReported { get; set; }
        public string ResolutionStatus { get; set; }

        public User User { get; set; } 
    }
}
