using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;
using Waste_Management_and_Recycling_System.Services;

namespace Waste_Management_and_Recycling_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecyclingPlantController : ControllerBase
    {
        private readonly IRecyclingPlantService _service;
        private readonly IUserRepo _userRepo;
        public RecyclingPlantController(IRecyclingPlantService service, IUserRepo userRepo)
        {
            _service = service;
            _userRepo = userRepo;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllRecyclingPlants()
        {
            var plants = await _service.GetAllPlants();
            return Ok(plants);
        }

        [HttpGet("{plantId}")]
        [Authorize(Roles ="Admin,Manager")]
        public async Task<IActionResult> GetRecyclingPlantById(int plantId)
        {
            var plant=_service.GetPlantById(plantId);
            if(plant==null)
                return NotFound();
            return Ok(plant);
        }

        [HttpGet("manager/{managerId}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetRecyclingPlantByManagerId(int managerId)
        {
            var plant = await _service.GetPlantByManagerId(managerId);
            if (plant == null)
                return NotFound();
            return Ok(plant);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddRecyclingPlant([FromBody] RecyclingPlantDTO recyclingPlantdto)
        {
            if (recyclingPlantdto == null)
                return BadRequest("Invalid data");
            RecyclingPlant rp = new RecyclingPlant
            {
                PlantId = recyclingPlantdto.PlantId,
                Name= recyclingPlantdto.Name,
                Location = recyclingPlantdto.Location,
                Capacity = recyclingPlantdto.Capacity,
                ProcessedMaterials = recyclingPlantdto.ProcessedMaterials,
                ManagerId = recyclingPlantdto.ManagerId,
            };
            var manager=_userRepo.GetUserById(rp.ManagerId);
            rp.Manager = manager;
            await _service.AddPlant(rp);
            return CreatedAtAction(nameof(GetRecyclingPlantById), new { plantId = rp.PlantId }, rp);
        }

        [HttpPut("{plantId}")]
        [Authorize(Roles ="Manager")]
        public async Task<IActionResult> UpdateRecyclingPlant(int plantId, [FromBody] RecyclingPlantDTO recyclingPlantdto)
        {
            if (recyclingPlantdto.PlantId != plantId)
                return BadRequest("Mismatched PlantId");
            var existingPlant = _service.GetPlantById(plantId);
            if (existingPlant == null)
                return NotFound();
            existingPlant.PlantId = recyclingPlantdto.PlantId;
            existingPlant.Name= recyclingPlantdto.Name;
            existingPlant.Location= recyclingPlantdto.Location;
            existingPlant.Capacity= recyclingPlantdto.Capacity;
            existingPlant.ProcessedMaterials= recyclingPlantdto.ProcessedMaterials;
            existingPlant.ManagerId = recyclingPlantdto.ManagerId;
            await _service.UpdatePlant(existingPlant);
            return NoContent();
        }

        [HttpDelete("{plantId}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteRecyclingPlant(int plantId)
        {
            var plant = _service.GetPlantById(plantId);
            if (plant == null)
                return NotFound();
            await _service.DeletePlant(plantId);
            return NoContent();
        }

    }
    public class RecyclingPlantDTO
    {
        public int PlantId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Capacity { get; set; }
        public string ProcessedMaterials { get; set; }
        public int ManagerId { get; set; }
    }
}
