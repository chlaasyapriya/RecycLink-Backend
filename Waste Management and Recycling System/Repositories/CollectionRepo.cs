using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public class CollectionRepo: ICollectionRepo
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public CollectionRepo(WasteManagementandRecyclingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Collection>> GetAllCollections()
        {
            return await _context.Collections.Include(c => c.Collector).ToListAsync();
        }
        public async Task<Collection> GetCollectionById(int id)
        {
            return await _context.Collections.Include(c => c.Collector).FirstOrDefaultAsync(c => c.CollectionId == id);
        }
        public async Task<IEnumerable<Collection>> GetCollectionsByCollector(int collectorId)
        {
            return await _context.Collections.Include(c=>c.Collector).Where(c=>c.CollectorId== collectorId).ToListAsync();
        }
        public async Task<IEnumerable<Collection>> GetCollectionsByStatus(string status)
        {
            return await _context.Collections.Include(c=>c.Collector).Where(c=>c.Status== status).ToListAsync();
        }
        public async Task AddCollection(Collection collection)
        {
            await _context.Collections.AddAsync(collection);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCollection(Collection collection)
        {
            _context.Collections.Update(collection);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCollection(int collectionId)
        {
            var collection = await _context.Collections.FindAsync(collectionId);
            if(collection != null)
            {
                _context.Collections.Remove(collection);
                await _context.SaveChangesAsync();
            }
        }
    }
}
