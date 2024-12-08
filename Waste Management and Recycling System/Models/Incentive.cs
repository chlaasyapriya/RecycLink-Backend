namespace Waste_Management_and_Recycling_System.Models
{
    public class Incentive
    {
        public int IncentiveId { get; set; }
        public int UserId { get; set; } 
        public int PointsEarned { get; set; }
        public string RewardType { get; set; }
        public DateTime RedemptionDate { get; set; }

        public User User { get; set; } 
    }
}
