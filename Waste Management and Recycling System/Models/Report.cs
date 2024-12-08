using System.ComponentModel.DataAnnotations;

namespace Waste_Management_and_Recycling_System.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        [Required]
        public string ReportType { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string Data { get; set; }
        public int CreatedBy { get; set; }

        public User Creator { get; set; } 
    }
}
