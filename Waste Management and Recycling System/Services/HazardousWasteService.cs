using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;

namespace Waste_Management_and_Recycling_System.Services
{
    public class HazardousWasteService:IHazardousWasteService
    {
        private readonly IHazardousWasteRepo _repository;
        public HazardousWasteService(IHazardousWasteRepo repository)
        {
            _repository = repository;
        }
        public async Task<List<HazardousWaste>> GetAllWaste()
        {
            return await _repository.GetAllWaste();
        }
        public HazardousWaste GetWasteById(int wasteId)
        {
            return _repository.GetWasteById(wasteId);
        }
        public async Task<List<HazardousWaste>> GetWastesByCollectorId(int collectorId)
        {
            return await _repository.GetWastesByCollectorId(collectorId);
        }
        public async Task<List<HazardousWaste>> GetWastesByRecyclingPlantId(int recyclingPlantId)
        {
            return await _repository.GetWastesByRecyclingPlantId(recyclingPlantId);
        }
        public async Task AddWaste(HazardousWaste waste)
        {
            await _repository.AddWaste(waste);
        }
        public async Task UpdateWaste(HazardousWaste waste)
        {
            await _repository.UpdateWaste(waste);
        }
        public async Task DeleteWaste(int wasteId)
        {
            await _repository.DeleteWaste(wasteId);
        }
    }
}
