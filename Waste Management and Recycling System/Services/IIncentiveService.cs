using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Services
{
    public interface IIncentiveService
    {
        public Task AddIncentive(int userId, int points, string rewardType);
        public Task<List<Incentive>> GetIncentivesByUserId(int userId);
        public Task<List<Incentive>> GetAllIncentives();
        public Task<List<RecyclingParticipation>> GetAllParticipations();

        public Task AddParticipation(RecyclingParticipation participation);
        public Task<List<RecyclingParticipation>> GetParticipationsByUserId(int userId);

        public int CalculatePoints(double weight, string wasteType);
        public string GetRewardType(string wasteType);

    }
}
