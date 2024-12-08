using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;

namespace Waste_Management_and_Recycling_System.Services
{
    public class RecyclingPlantService: IRecyclingPlantService
    {
        private readonly IRecyclingPlantRepo _repo;
        public RecyclingPlantService(IRecyclingPlantRepo repo)
        {
            _repo = repo;
        }
        public RecyclingPlant GetPlantById(int id)
        {
            return _repo.GetPlantById(id);
        }
        public async Task<RecyclingPlant?> GetPlantByManagerId(int id)
        {
            return await _repo.GetPlantByManagerId(id);
        }
        public async Task<IEnumerable<RecyclingPlant>> GetAllPlants()
        {
            return await _repo.GetAllPlants();
        }
        public async Task AddPlant(RecyclingPlant plant)
        {
            await _repo.AddPlant(plant);
        }
        public async Task UpdatePlant(RecyclingPlant plant)
        {
            await _repo.UpdatePlant(plant);
        }
        public async Task DeletePlant(int id)
        {
            await _repo.DeletePlant(id);
        }
    }
}
