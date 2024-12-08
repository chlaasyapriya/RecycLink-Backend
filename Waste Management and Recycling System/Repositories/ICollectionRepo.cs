using System.Collections.ObjectModel;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public interface ICollectionRepo
    {
        public Task<IEnumerable<Collection>> GetAllCollections();
        public Task<Collection> GetCollectionById(int id);
        public Task<IEnumerable<Collection>> GetCollectionsByCollector(int collectorId);
        public Task<IEnumerable<Collection>> GetCollectionsByStatus(string status);
        public Task AddCollection(Collection collection);
        public Task UpdateCollection(Collection collection);
        public Task DeleteCollection(int collectionId);

    }
}
