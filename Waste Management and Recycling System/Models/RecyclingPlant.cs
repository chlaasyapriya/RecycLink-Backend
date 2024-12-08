using Microsoft.Identity.Client.Extensions.Msal;
using System.ComponentModel.DataAnnotations;

namespace Waste_Management_and_Recycling_System.Models
{
    public class RecyclingPlant
    {
        public int PlantId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public double Capacity { get; set; }
        public string ProcessedMaterials { get; set; }
        public int ManagerId { get; set; } 

        public User Manager { get; set; }
    }
}

