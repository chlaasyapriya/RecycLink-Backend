using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public class RecyclingPlantRepo:IRecyclingPlantRepo
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public RecyclingPlantRepo(WasteManagementandRecyclingDbContext context)
        {
            _context = context;
        }
        public RecyclingPlant GetPlantById(int id)
        {
            return _context.RecyclingPlants.FirstOrDefault(rp => rp.PlantId == id);
        }
        public async Task<RecyclingPlant?> GetPlantByManagerId(int id)
        {
            return await _context.RecyclingPlants.FirstOrDefaultAsync( rp => rp.ManagerId == id);
        }
        public async Task<IEnumerable<RecyclingPlant>> GetAllPlants()
        {
            return await _context.RecyclingPlants.ToListAsync();
        }
        public async Task AddPlant(RecyclingPlant plant)
        {
            await _context.RecyclingPlants.AddAsync(plant);
            _context.SaveChangesAsync();
        }
        public async Task UpdatePlant(RecyclingPlant plant)
        {
            _context.RecyclingPlants.Update(plant);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePlant(int id)
        {
            var recyclingPlant=GetPlantById(id);
            if (recyclingPlant != null)
            {
                _context.RecyclingPlants.Remove(recyclingPlant);
                await _context.SaveChangesAsync();
            }
        }
    }
}
