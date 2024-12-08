using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public class HazardousWasteRepo: IHazardousWasteRepo
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public HazardousWasteRepo(WasteManagementandRecyclingDbContext context)
        {
            _context = context;
        }
        public async Task<List<HazardousWaste>> GetAllWaste()
        {
            return await _context.HazardousWastes.ToListAsync();
        }
        public HazardousWaste GetWasteById(int wasteId)
        {
            return  _context.HazardousWastes.Find(wasteId);
        }
        public async Task<List<HazardousWaste>> GetWastesByCollectorId(int collectorId)
        {
            return await _context.HazardousWastes.Where(w=>w.CollectorId== collectorId).ToListAsync();
        }
        public async Task<List<HazardousWaste>> GetWastesByRecyclingPlantId(int recyclingPlantId)
        {
            return await _context.HazardousWastes.Where(w=>w.RecyclingPlantId== recyclingPlantId).ToListAsync();  
        }
        public async Task AddWaste(HazardousWaste waste)
        {
            await _context.HazardousWastes.AddAsync(waste);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateWaste(HazardousWaste waste)
        {
            _context.HazardousWastes.Update(waste);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteWaste(int wasteId)
        {
            var waste = await _context.HazardousWastes.FindAsync(wasteId);
            if (waste != null)
            {
                _context.HazardousWastes.Remove(waste);
                await _context.SaveChangesAsync();
            }
        }
    }
}
