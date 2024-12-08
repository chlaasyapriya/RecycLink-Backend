using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Services
{
    public interface ITrainingService
    {
        public Task<IEnumerable<Training>> GetAllTrainings();
        public Task<IEnumerable<Training>> GetTrainingByAudience(string audience);
        public Task<Training> GetTrainingById(int trainingId);
        public Task AddTraining(Training training);
        public Task UpdateTraining(Training training);
        public Task DeleteTraining(int trainingId);
    }
}
