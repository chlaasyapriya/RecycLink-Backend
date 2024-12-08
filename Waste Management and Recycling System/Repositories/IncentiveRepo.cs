using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public class IncentiveRepo: IIncentiveRepo
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public IncentiveRepo(WasteManagementandRecyclingDbContext context)
        {
            _context = context;
        }
        public async Task AddIncentive(Incentive incentive)
        {
            await _context.Incentives.AddAsync(incentive);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Incentive>> GetIncentivesByUserId(int userId)
        {
            return await _context.Incentives.Where(i => i.UserId == userId).ToListAsync();
        }
        public async Task<List<Incentive>> GetAllIncentives()
        {
            return await _context.Incentives.ToListAsync();
        }
        public async Task<List<RecyclingParticipation>> GetAllParticipations()
        {
            return await _context.RecyclingParticipations.ToListAsync();
        }
        public async Task AddParticipation(RecyclingParticipation participation)
        {
            await _context.RecyclingParticipations.AddAsync(participation);
            await _context.SaveChangesAsync();
        }
        public async Task<List<RecyclingParticipation>> GetParticipationsByUserId(int userId)
        {
            return await _context.RecyclingParticipations.Where(rp => rp.UserId == userId).ToListAsync();
        }
    }

    
}
