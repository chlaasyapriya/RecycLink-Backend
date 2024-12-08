using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public class TrainingRepo: ITrainingRepo
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public TrainingRepo(WasteManagementandRecyclingDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Training>> GetAllTrainings()
        {
            return await _context.Trainings.ToListAsync();
        }
        public async Task<IEnumerable<Training>> GetTrainingByAudience(string audience)
        {
            return await _context.Trainings.Where(t=>t.AudienceType==audience).ToListAsync();
        }
        public async Task<Training> GetTrainingById(int trainingId)
        {
            return await _context.Trainings.FirstOrDefaultAsync(t => t.TrainingId == trainingId);
        }
        public async Task AddTraining(Training training)
        {
            await _context.Trainings.AddAsync(training);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTraining(Training training)
        {
            _context.Trainings.Update(training);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTraining(int trainingId)
        {
            var training = await GetTrainingById(trainingId);
            if (training != null)
            {
                _context.Trainings.Remove(training);
                await _context.SaveChangesAsync();
            }
        }
    }
}
