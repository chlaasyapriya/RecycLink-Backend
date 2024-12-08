using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;

namespace Waste_Management_and_Recycling_System.Services
{
    public class IncentiveService: IIncentiveService
    {
        private readonly IIncentiveRepo _incentiveRepo;
        public IncentiveService(IIncentiveRepo incentiveRepo)
        {
            _incentiveRepo = incentiveRepo;
        }
        public async Task AddIncentive(int userId, int points, string rewardType)
        {
            var incentive = new Incentive
            {
                UserId = userId,
                PointsEarned = points,
                RewardType = rewardType,
                RedemptionDate = DateTime.Now.AddDays(14),
            };
            await _incentiveRepo.AddIncentive(incentive);
        }
        public async Task<List<Incentive>> GetIncentivesByUserId(int userId)
        {
            return await _incentiveRepo.GetIncentivesByUserId(userId);
        }
        public async Task<List<Incentive>> GetAllIncentives()
        {
            return await _incentiveRepo.GetAllIncentives();
        }
        public async Task<List<RecyclingParticipation>> GetAllParticipations()
        {
            return await _incentiveRepo.GetAllParticipations();
        }

        public async Task AddParticipation(RecyclingParticipation participation)
        {
            await _incentiveRepo.AddParticipation(participation);
        }
        public async Task<List<RecyclingParticipation>> GetParticipationsByUserId(int userId)
        {
            return await _incentiveRepo.GetParticipationsByUserId(userId) ;
        }

        public int CalculatePoints( double weight, string wasteType)
        {
            int x = (int)weight;
            if (wasteType == "paper")
                return 5 * x;
            else if (wasteType == "glass")
                return 3 * x;
            else if(wasteType=="metal")
                return 2 * x;
            return x;
        }

        public string GetRewardType(string wasteType)
        {
            if (wasteType == "glass")
                return "electronics";
            else if (wasteType == "paper")
                return "cosmetics";
            else if (wasteType == "metal")
                return "giftcard";
            else
                return "shopping";
        }
    }
}
