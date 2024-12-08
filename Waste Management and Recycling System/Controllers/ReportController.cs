using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waste_Management_and_Recycling_System.Services;

namespace Waste_Management_and_Recycling_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GenerateWeeklyReport()
        {
            var report = await _reportService.GenerateWeeklyReport();
            return Ok(report);
        }
    }
}
