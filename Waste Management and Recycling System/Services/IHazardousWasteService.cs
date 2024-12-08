using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Services
{
    public interface IHazardousWasteService
    {
        public Task<List<HazardousWaste>> GetAllWaste();
        public HazardousWaste GetWasteById(int wasteId);
        public Task<List<HazardousWaste>> GetWastesByCollectorId(int collectorId);
        public Task<List<HazardousWaste>> GetWastesByRecyclingPlantId(int recyclingPlantId);
        public Task AddWaste(HazardousWaste waste);
        public Task UpdateWaste(HazardousWaste waste);
        public Task DeleteWaste(int wasteId);
    }
}
