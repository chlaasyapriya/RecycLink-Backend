using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;

namespace Waste_Management_and_Recycling_System.Services
{
    public class CollectionService: ICollectionService
    {
        private readonly ICollectionRepo _collectionRepo;
        public CollectionService(ICollectionRepo collectionRepo)
        {
            _collectionRepo = collectionRepo;
        }

        public async Task<IEnumerable<Collection>> GetAllCollections()
        {
            return await _collectionRepo.GetAllCollections();
        }
        public async Task<Collection> GetCollectionById(int id)
        {
            return await _collectionRepo.GetCollectionById(id);
        }
        public async Task<IEnumerable<Collection>> GetCollectionsByCollector(int collectorId)
        {
            return await _collectionRepo.GetCollectionsByCollector(collectorId);
        }
        public async Task<IEnumerable<Collection>> GetCollectionsByStatus(string status)
        {
            return await _collectionRepo.GetCollectionsByStatus(status);
        }
        public async Task AddCollection(Collection collection)
        {
            await _collectionRepo.AddCollection(collection);
        }
        public async Task UpdateCollection(Collection collection)
        {
            await _collectionRepo.UpdateCollection(collection);
        }
        public async Task DeleteCollection(int collectionId)
        {
            await _collectionRepo.DeleteCollection(collectionId);
        }
    }
}
