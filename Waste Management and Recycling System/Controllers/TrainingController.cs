using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;
using Waste_Management_and_Recycling_System.Services;

namespace Waste_Management_and_Recycling_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        private readonly IUserRepo _userRepo;
        public TrainingController(ITrainingService trainingService, IUserRepo userRepo)
        {
            _trainingService = trainingService;
            _userRepo = userRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTrainings()
        {
            var trainings = await _trainingService.GetAllTrainings();
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingById(int id)
        {
            var training = await _trainingService.GetTrainingById(id);
            if (training == null)
                return NotFound();
            return Ok(training);
        }

        [HttpGet("audienceType/{audienceType}")]
        public async Task<IActionResult> GetTrainingsByAudienceType(string audienceType)
        {
            var training = await _trainingService.GetTrainingByAudience(audienceType);
            if (training == null)
                return NotFound();
            return Ok(training);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTraining([FromBody] TrainingDTO trainingdto)
        {
            if (trainingdto == null)
                return BadRequest("Invalid training data");
            var training = new Training
            {
                AudienceType = trainingdto.AudienceType,
                Content = trainingdto.Content,
                DateScheduled = trainingdto.DateScheduled,
                TrainerId = trainingdto.TrainerId
            };
            var user = _userRepo.GetUserById(training.TrainerId);
            training.Trainer= user;
            await _trainingService.AddTraining(training);
            return CreatedAtAction(nameof(GetTrainingById), new { id = training.TrainingId }, training);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTraining(int id, [FromBody] TrainingDTO trainingdto)
        {
            if (trainingdto == null)
                return BadRequest("Invalid training data");
            var existingTraining = await _trainingService.GetTrainingById(id);
            if (existingTraining == null)
                return NotFound();
            existingTraining.AudienceType = trainingdto.AudienceType;
            existingTraining.Content = trainingdto.Content;
            existingTraining.DateScheduled = trainingdto.DateScheduled;
            existingTraining.TrainerId= trainingdto.TrainerId;
            var user= _userRepo.GetUserById(existingTraining.TrainingId);
            existingTraining.Trainer= user;
            await _trainingService.UpdateTraining(existingTraining);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            var existingTraining = await _trainingService.GetTrainingById(id);
            if (existingTraining == null)
                return NotFound();

            await _trainingService.DeleteTraining(id);
            return NoContent();
        }
    }
    public class TrainingDTO
    {
        public string AudienceType { get; set; }
        public string Content { get; set; }
        public DateTime DateScheduled { get; set; }
        public int TrainerId { get; set; }
    }
}
