namespace Waste_Management_and_Recycling_System.Models
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string AudienceType { get; set; }
        public string Content { get; set; }
        public DateTime DateScheduled { get; set; }
        public int TrainerId { get; set; } 

        public User Trainer { get; set; } 
    }
}
