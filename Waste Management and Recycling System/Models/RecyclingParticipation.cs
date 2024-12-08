namespace Waste_Management_and_Recycling_System.Models
{
    public class RecyclingParticipation
    {
        public int ParticipationId { get; set; }
        public int UserId { get; set; }
        public double Weight { get; set; }
        public string WasteType { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual User User { get; set; }
    }
}
