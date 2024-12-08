using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Services;

namespace Waste_Management_and_Recycling_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResources()
        {
            var resources = await _resourceService.GetAllResources();
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceById(int id)
        {
            var resource = await _resourceService.GetResourceById(id);
            if (resource == null)
                return NotFound();

            return Ok(resource);
        }

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetResourcesByType(string type)
        {
            var resources = await _resourceService.GetResourcesByType(type);
            return Ok(resources);
        }

        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody] Resource resource)
        {
            if (resource == null)
                return BadRequest("Invalid resource data");

            await _resourceService.AddResource(resource);
            return CreatedAtAction(nameof(GetResourceById), new { id = resource.ResourceId }, resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResource(int id, [FromBody] Resource resource)
        {
            if (resource == null || resource.ResourceId != id)
                return BadRequest("Invalid resource data");

            var existingResource = await _resourceService.GetResourceById(id);
            if (existingResource == null)
                return NotFound();

            await _resourceService.UpdateResource(resource);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(int id)
        {
            var existingResource = await _resourceService.GetResourceById(id);
            if (existingResource == null)
                return NotFound();

            await _resourceService.DeleteResource(id);
            return NoContent();
        }

    }
}
