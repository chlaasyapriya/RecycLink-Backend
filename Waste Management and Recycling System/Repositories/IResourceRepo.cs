using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public interface IResourceRepo
    {
        public Task<IEnumerable<Resource>> GetAllResources();
        public Task<Resource> GetResourceById(int resourceId);
        public Task<IEnumerable<Resource>> GetResourcesByType(string type);
        public Task AddResource(Resource resource);
        public Task UpdateResource(Resource resource);
        public Task DeleteResource(int resourceId);
    }
}
