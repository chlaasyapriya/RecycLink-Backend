using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Services
{
    public interface IRecyclingPlantService
    {
        public RecyclingPlant GetPlantById(int id);
        public Task<RecyclingPlant?> GetPlantByManagerId(int id);
        public Task<IEnumerable<RecyclingPlant>> GetAllPlants();
        public Task AddPlant(RecyclingPlant plant);
        public Task UpdatePlant(RecyclingPlant plant);
        public Task DeletePlant(int id);
    }
}
