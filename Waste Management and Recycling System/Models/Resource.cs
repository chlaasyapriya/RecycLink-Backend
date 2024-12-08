using System.ComponentModel.DataAnnotations;

namespace Waste_Management_and_Recycling_System.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        [Required]
        public string Type { get; set; }
        public double Quantity { get; set; }
        public string Location { get; set; }
        public DateTime MaintenanceDate { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
