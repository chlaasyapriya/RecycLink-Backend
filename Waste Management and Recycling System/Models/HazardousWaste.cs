using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Waste_Management_and_Recycling_System.Models
{
    public class HazardousWaste
    {
        public int WasteId { get; set; }
        [Required]
        public string Type { get; set; }
        public string Location { get; set; }
        public DateTime DateCollected { get; set; }
        public string DisposalStatus { get; set; }
        public int CollectorId { get; set; }
        [JsonIgnore]
        public User Collector { get; set; }
        public int RecyclingPlantId { get; set; }
        [JsonIgnore]
        public RecyclingPlant RecyclingPlant { get; set; }
    }
}
