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
    public class IncentiveController : ControllerBase
    {
        private readonly IIncentiveService _incentiveService;
        private readonly IUserRepo _userRepo;
        private readonly INotificationService _notificationService;
        public IncentiveController(IIncentiveService incentiveService,IUserRepo userRepo, INotificationService notificationService)
        {
            _incentiveService = incentiveService;
            _userRepo = userRepo;
            _notificationService = notificationService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetIncentivesByUserId(int userId)
        {
            var incentives = await _incentiveService.GetIncentivesByUserId(userId);
            return Ok(incentives);
        }

        [HttpGet("incentives")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllIncentives()
        {
            var incentives=await _incentiveService.GetAllIncentives();
            return Ok(incentives);
        }
        [HttpGet("participations")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllParticipations()
        {
            var participations=await _incentiveService.GetAllParticipations();
            return Ok(participations);
        }

        [HttpPost("participation/add")]
        [Authorize(Roles = "Resident")]
        public async Task<IActionResult> AddParticipation([FromBody] RecyclingParticipationDto participationDto)
        {
            var participation = new RecyclingParticipation
            {
                UserId = participationDto.UserId,
                Weight = participationDto.Weight,
                WasteType = participationDto.WasteType,
                SubmissionDate = DateTime.UtcNow
            };
            await _incentiveService.AddParticipation(participation);
            var pointsEarned = _incentiveService.CalculatePoints(participationDto.Weight,participationDto.WasteType);
            var rewardType= _incentiveService.GetRewardType(participationDto.WasteType);
            var resident = _userRepo.GetUserById(participationDto.UserId);
            await _incentiveService.AddIncentive(participationDto.UserId, pointsEarned, rewardType);
            await _notificationService.SendNotification(resident.UserId, resident.Email, resident.Username, "Incentive added", "New incentive of " + rewardType + "  is added", "Incentive");
            return Ok("Participation added successfully.");
        }

        [HttpGet("participation/user/{userId}")]
        public async Task<IActionResult> GetParticipationsByUserId(int userId)
        {
            var participations = await _incentiveService.GetParticipationsByUserId(userId);
            return Ok(participations);
        }

    }
    public class IncentiveDto
    {
        public int UserId { get; set; }
        public int PointsEarned { get; set; }
        public string RewardType { get; set; }
    }
    public class RecyclingParticipationDto
    {
        public int UserId { get; set; }
        public double Weight { get; set; }
        public string WasteType { get; set; }
    }
}
