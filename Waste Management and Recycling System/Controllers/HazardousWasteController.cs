using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;
using Waste_Management_and_Recycling_System.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Waste_Management_and_Recycling_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HazardousWasteController : ControllerBase
    {
        private readonly IHazardousWasteService _hazardousWasteService;
        private readonly IUserRepo _userRepo;
        private readonly IRecyclingPlantRepo _plantRepo;
        private readonly INotificationService _notificationService;
        public HazardousWasteController(IHazardousWasteService hazardousWasteService, IUserRepo userRepo, IRecyclingPlantRepo plantRepo, INotificationService notificationService)
        {
            _hazardousWasteService = hazardousWasteService;
            _userRepo = userRepo;
            _plantRepo = plantRepo;
            _notificationService = notificationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllWaste()
        {
            var wastes = await _hazardousWasteService.GetAllWaste();
            return Ok(wastes);
        }

        [HttpGet("collector/{collectorId}")]
        public async Task<IActionResult> GetWasteByCollector(int collectorId)
        {
            var wastes=await _hazardousWasteService.GetWastesByCollectorId(collectorId);
            return Ok(wastes);
        }

        [HttpGet("plant/{plantId}")]
        public async Task<IActionResult> GetWasteByPlant(int plantId)
        {
            var waste=await _hazardousWasteService.GetWastesByRecyclingPlantId(plantId);
            return Ok(waste);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddWaste([FromBody] HazardousWasteDTO wastedto)
        {
            var waste = new HazardousWaste
            {
                Type = wastedto.Type,
                Location = wastedto.Location,
                DateCollected = wastedto.DateCollected,
                DisposalStatus = wastedto.DisposalStatus,
                CollectorId = wastedto.CollectorId,
                RecyclingPlantId=wastedto.RecyclingPlantId,
            };
            var collector=_userRepo.GetUserById(waste.CollectorId);
            waste.RecyclingPlant = _plantRepo.GetPlantById(waste.RecyclingPlantId);
            var manager = _userRepo.GetUserById(waste.RecyclingPlant.ManagerId);
            await _notificationService.SendNotification(waste.CollectorId, collector.Email, collector.Username, "Hazardous Waste Collection Added", "New hazardous waste collection at " + waste.Location + " is added", "Hazardouswaste");
            await _notificationService.SendNotification(manager.UserId, manager.Email, manager.Username, "Hazardous Waste Collection Added", "New hazardous waste collection at " + waste.Location + " is added", "Hazardouswaste");
            await _hazardousWasteService.AddWaste(waste);
            return Ok("Waste added successfully.");
        }

        [HttpPut("{wasteId}")]
        [Authorize(Roles = "Manager, Admin, Collector")]
        public async Task<IActionResult> UpdateWaste(int wasteId, [FromBody] HazardousWasteDTO waste)
        {
            var existingWaste =  _hazardousWasteService.GetWasteById(wasteId);
            existingWaste.Type = waste.Type;
            existingWaste.Location = waste.Location;
            existingWaste.DisposalStatus = waste.DisposalStatus;
            existingWaste.DateCollected = waste.DateCollected;
            await _hazardousWasteService.UpdateWaste(existingWaste);
            return Ok("Waste updated successfully.");
        }

        [HttpDelete("{wasteId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteWaste(int wasteId)
        {
            var waste=_hazardousWasteService.GetWasteById(wasteId);
            var collector = _userRepo.GetUserById(waste.CollectorId);
            var plant = _plantRepo.GetPlantById(waste.RecyclingPlantId);
            var manager = _userRepo.GetUserById(plant.ManagerId);
            await _notificationService.SendNotification(collector.UserId, collector.Email, collector.Username, "Hazardous Waste Collection Deleted", "Hazardous waste collection at " + waste.Location + " is deleted", "Hazardouswaste");
            await _notificationService.SendNotification(manager.UserId, manager.Email, manager.Username, "Hazardous Waste Collection Deleted", "Hazardous waste collection at " + waste.Location + " is deleted", "Hazardouswaste");
            await _hazardousWasteService.DeleteWaste(wasteId);
            return Ok("Waste deleted successfully.");
        }
    }
    public class HazardousWasteDTO
    {
        public string Type { get; set; }
        public string Location { get; set; }
        public DateTime DateCollected { get; set; }
        public string DisposalStatus { get; set; }
        public int CollectorId { get; set; }
        public int RecyclingPlantId { get; set; }
    }

}
