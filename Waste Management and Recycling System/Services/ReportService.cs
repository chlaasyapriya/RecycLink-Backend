using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;

namespace Waste_Management_and_Recycling_System.Services
{
    public class ReportService: IReportService
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public ReportService(WasteManagementandRecyclingDbContext context)
        {
            _context = context;
        }
        public async Task<WeeklyReportDto> GenerateWeeklyReport()
        {
            var startOfWeek = DateTime.UtcNow.AddDays(-(int)DateTime.UtcNow.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7);
            var weeklyComplaints = await _context.Complaints.Where(c => c.DateReported >= startOfWeek && c.DateReported < endOfWeek).ToListAsync();
            var weeklyCollections = await _context.Collections.Where(c => c.PickupDate >= startOfWeek && c.PickupDate < endOfWeek).ToListAsync();
            var weeklyEvents = await _context.Events.Where(e => e.Date >= startOfWeek && e.Date < endOfWeek).ToListAsync();
            var weeklyTrainings = await _context.Trainings.Where(t => t.DateScheduled >= startOfWeek && t.DateScheduled < endOfWeek).ToListAsync();
            return new WeeklyReportDto
            {
                WeeklyComplaints = weeklyComplaints,
                WeeklyCollectionsCount = weeklyCollections.Count,
                WeeklyEvents = weeklyEvents,
                WeeklyTrainings = weeklyTrainings,
            };
        }

    }
}
