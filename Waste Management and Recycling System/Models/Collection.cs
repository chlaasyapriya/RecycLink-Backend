using System.ComponentModel.DataAnnotations;

namespace Waste_Management_and_Recycling_System.Models
{
    public class Collection
    {
        public int CollectionId { get; set; }
        public int CollectorId { get; set; } 
        public string Location { get; set; }
        [Required]
        public string WasteType { get; set; }
        [Required]
        public DateTime PickupDate { get; set; }
        public double Quantity { get; set; }
        [Required]
        public string Status { get; set; }

        public User Collector { get; set; } 
    }
}
