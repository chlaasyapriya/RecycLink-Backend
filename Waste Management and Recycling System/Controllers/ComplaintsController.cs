using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;
using Waste_Management_and_Recycling_System.Services;

namespace Waste_Management_and_Recycling_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly IComplaintService _complaintService;
        private readonly INotificationService _notificationService;
        public ComplaintsController(IComplaintService complaintService, INotificationService notificationService)
        {
            _complaintService = complaintService;
            _notificationService = notificationService;
        }

        [HttpPost]
        [Authorize(Roles ="Resident")]
        public async Task<IActionResult> FileComplaint([FromBody] AddComplaintDTO complaintdto)
        {
            if (complaintdto == null)
                return BadRequest("Enter the complaint details");
            var complaint = new Complaint
            {
                UserId = complaintdto.UserId,
                IssueType = complaintdto.IssueType,
                Description = complaintdto.Description,
            };
            complaint.DateReported = DateTime.Now;
            complaint.ResolutionStatus = "Unresolved";
            await _complaintService.AddComplaint(complaint);
            return Ok("Complaint filed successfully.");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllComplaints()
        {
            var complaints = await _complaintService.GetAllComplaints();
            return Ok(complaints);
        }

        [HttpGet("status/{status}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetComplaintsByStatus(string status)
        {
            var complaints = await _complaintService.GetComplaintsByStatus(status);
            return Ok(complaints);
        }

        [HttpGet("resident/{residentId}")]
        [Authorize(Roles = "Resident,Admin")]
        public async Task<IActionResult> GetComplaintsByResidentId(int residentId)
        {
            var complaints = await _complaintService.GetComplaintsByResidentId(residentId);
            return Ok(complaints);
        }

        [HttpGet("resident/{residentId}/status/{status}")]
        [Authorize(Roles = "Resident,Admin")]
        public async Task<IActionResult> GetComplaintsByResidentIdAndStatus(int residentId, string status)
        {
            var complaints = await _complaintService.GetComplaintsByResidentIdAndStatus(residentId, status);
            return Ok(complaints);
        }

        [HttpPut("{complaintId}/status/{resolutionStatus}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateComplaintStatus(int complaintId, string resolutionStatus)
        {
            var complaint=_complaintService.GetComplaintById(complaintId);
            await _complaintService.UpdateComplaintStatus(complaintId, resolutionStatus);
            return Ok("Complaint status updated successfully.");
        }

        [HttpDelete("{complaintId}")]
        [Authorize(Roles = "Resident")]
        public async Task<IActionResult> DeleteComplaint(int complaintId)
        {
            await _complaintService.DeleteComplaint(complaintId);
            return Ok("Complaint deleted successfully.");
        }
    }
    public class AddComplaintDTO
    {
        public int UserId { get; set; }
        public string IssueType { get; set; }
        public string Description { get; set; }
    }
}
