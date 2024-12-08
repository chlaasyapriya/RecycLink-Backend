using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public interface IIncentiveRepo
    {
        public Task AddIncentive(Incentive incentive);
        public Task<List<Incentive>> GetIncentivesByUserId(int userId);
        public Task<List<Incentive>> GetAllIncentives();
        public Task<List<RecyclingParticipation>> GetAllParticipations();

        public Task AddParticipation(RecyclingParticipation participation);
        public Task<List<RecyclingParticipation>> GetParticipationsByUserId(int userId);
    }
}
