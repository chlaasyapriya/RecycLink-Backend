using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;

namespace Waste_Management_and_Recycling_System.Services
{
    public class ResourceService: IResourceService
    {
        private readonly IResourceRepo _resourceRepo;
        public ResourceService(IResourceRepo resourceRepo)
        {
            _resourceRepo = resourceRepo;
        }
        public async Task<IEnumerable<Resource>> GetAllResources()
        {
            return await _resourceRepo.GetAllResources();
        }
        public async Task<Resource> GetResourceById(int resourceId)
        {
            return await _resourceRepo.GetResourceById(resourceId);
        }
        public async Task<IEnumerable<Resource>> GetResourcesByType(string type)
        {
            return await _resourceRepo.GetResourcesByType(type);
        }
        public async Task AddResource(Resource resource)
        {
            await _resourceRepo.AddResource(resource);
        }
        public async Task UpdateResource(Resource resource)
        {
            await _resourceRepo.UpdateResource(resource);
        }
        public async Task DeleteResource(int resourceId)
        {
            await _resourceRepo.DeleteResource(resourceId);
        }
    }
}
