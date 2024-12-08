using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;

namespace Waste_Management_and_Recycling_System.Services
{
    public class TrainingService: ITrainingService
    {
        private readonly ITrainingRepo _repository;
        public TrainingService(ITrainingRepo repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Training>> GetAllTrainings()
        {
            return await _repository.GetAllTrainings();
        }
        public async Task<IEnumerable<Training>> GetTrainingByAudience(string audience)
        {
            return await _repository.GetTrainingByAudience(audience);
        }
        public async Task<Training> GetTrainingById(int trainingId)
        {
            return await _repository.GetTrainingById(trainingId);
        }
        public async Task AddTraining(Training training)
        {
            await _repository.AddTraining(training);
        }
        public async Task UpdateTraining(Training training)
        {
            await _repository.UpdateTraining(training);
        }
        public async Task DeleteTraining(int trainingId)
        {
            await _repository.DeleteTraining(trainingId);
        }
    }
}
