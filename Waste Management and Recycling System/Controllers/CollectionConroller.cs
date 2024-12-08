using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;
using Waste_Management_and_Recycling_System.Services;

namespace Waste_Management_and_Recycling_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionConroller : ControllerBase
    {
        private readonly ICollectionService _collectionService;
        private readonly IUserRepo _userRepo;
        private INotificationService _notificationService;
        public CollectionConroller(ICollectionService collectionService, IUserRepo userRepo, INotificationService notificationService)
        {
            _collectionService = collectionService;
            _userRepo = userRepo;
            _notificationService = notificationService;
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllCollections()
        {
            var collections = await _collectionService.GetAllCollections();
            return Ok(collections);
        }
        [HttpGet("{collectionId}")]
        [Authorize(Roles = "Admin,Collector")]
        public async Task<IActionResult> GetCollectionById(int collectionId)
        {
            var collection = await _collectionService.GetCollectionById(collectionId);
            if (collection == null)
                return NotFound();
            return Ok(collection);
        }

        [HttpGet("collector/{collectorId}")]
        [Authorize(Roles = "Admin,Collector")]
        public async Task<IActionResult> GetCollectionsByCollector(int collectorId)
        {
            var collections = await _collectionService.GetCollectionsByCollector(collectorId);
            if (collections == null)
                return NotFound();
            return Ok(collections);
        }
        [HttpGet("status/{status}")]
        [Authorize(Roles = "Admin,Collector")]
        public async Task<IActionResult> GetCollectionByStatus(string status)
        {
            var collections = await _collectionService.GetCollectionsByStatus(status);
            if (collections == null || !collections.Any())
                return NotFound();
            return Ok(collections);
        }
        [HttpGet("collector/{collectorId}/status/{status}")]
        public async Task<IActionResult> GetCollectionsByCollectorAndStatus(int collectorId, string status)
        {
            var collections = await _collectionService.GetCollectionsByStatus(status);
            if (collections == null || !collections.Any())
                return NotFound();
            collections=collections.Where(c=>c.CollectorId== collectorId).ToList();
            if (collections == null || !collections.Any())
                return NotFound();
            return Ok(collections);
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Collector")]
        public async Task<IActionResult> AddCollection([FromBody] CollectionData collectionData)
        {
            if (collectionData == null)
                return BadRequest("Invalid Collection Data");
            var collector = _userRepo.GetUserById(collectionData.CollectorId);
            if (collector == null)
                return BadRequest("Invalid Collector");
            Collection collection = new Collection
            {
                CollectorId = collectionData.CollectorId,
                Location = collectionData.Location,
                WasteType = collectionData.WasteType,
                PickupDate = collectionData.PickupDate,
                Quantity = collectionData.Quantity,
                Status = collectionData.Status
            };
            collection.Collector=collector;
            await _collectionService.AddCollection(collection);
            await _notificationService.SendNotification(collection.CollectorId, collection.Collector.Email, collection.Collector.Username, "Collection added", "New collection at " + collection.Location + " added", "Collection");
            return CreatedAtAction(nameof(GetCollectionById), new { collectionId = collection.CollectionId }, collection);
        }

        [HttpPut("{collectionId}")]
        [Authorize(Roles = "Collector, Admin")]
        public async Task<IActionResult> UpdateCollection(int collectionId, [FromBody] CollectionData collectionData)
        {
            if (collectionData == null || collectionData.CollectionId != collectionId)
                return BadRequest("Invalid Collection Data");
            var collector = _userRepo.GetUserById(collectionData.CollectorId);
            if (collector == null)
                return BadRequest("Invalid Collector");
            var existingCollection = await _collectionService.GetCollectionById(collectionId);
            if (existingCollection == null)
                return NotFound($"No collection found with ID {collectionId}");
            existingCollection.CollectorId = collectionData.CollectorId;
            existingCollection.Location = collectionData.Location;
            existingCollection.WasteType = collectionData.WasteType;
            existingCollection.PickupDate = collectionData.PickupDate;
            existingCollection.Quantity = collectionData.Quantity;
            existingCollection.Status = collectionData.Status;
            await _collectionService.UpdateCollection(existingCollection);
            await _notificationService.SendNotification(existingCollection.CollectorId, existingCollection.Collector.Email, existingCollection.Collector.Username, "Collection updated", "Collection at " + existingCollection.Location + " is updated", "Collection");
            return CreatedAtAction(nameof(GetCollectionById), new { collectionId = existingCollection.CollectionId }, existingCollection);
        }

        [HttpDelete("{collectionId}")]
        [Authorize(Roles = "Admin,Collector")]
        public async Task<IActionResult> DeleteCollection(int collectionId)
        {
            var collection = await _collectionService.GetCollectionById(collectionId);
            if (collection == null) return NotFound("Collection not found");
            await _notificationService.SendNotification(collection.CollectorId, collection.Collector.Email, collection.Collector.Username, "Collection deleted", "Collection at " + collection.Location + " is deleted", "Collection");
            await _collectionService.DeleteCollection(collectionId);
            return NoContent();
        }
    }
    public class CollectionData
    {
        public int CollectionId { get; set; }
        public int CollectorId { get; set; }
        public string Location { get; set; }
        public string WasteType { get; set; }
        public DateTime PickupDate { get; set; }
        public double Quantity { get; set; }
        public string Status { get; set; }
    }
}
