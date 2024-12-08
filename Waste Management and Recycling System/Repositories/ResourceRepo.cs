using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public class ResourceRepo: IResourceRepo
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public ResourceRepo(WasteManagementandRecyclingDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Resource>> GetAllResources()
        {
            return await _context.Resources.ToListAsync();
        }
        public async Task<Resource> GetResourceById(int resourceId)
        {
            return await _context.Resources.FirstOrDefaultAsync(r => r.ResourceId == resourceId);
        }
        public async Task<IEnumerable<Resource>> GetResourcesByType(string type)
        {
            return await _context.Resources.Where(r=>r.Type == type).ToListAsync();
        }
        public async Task AddResource(Resource resource)
        {
            await _context.Resources.AddAsync(resource);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateResource(Resource resource)
        {
            _context.Resources.Update(resource);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteResource(int resourceId)
        {
            var resource = await GetResourceById(resourceId);
            if (resource != null)
            {
                _context.Resources.Remove(resource);
                await _context.SaveChangesAsync();
            }
        }
    }
}
