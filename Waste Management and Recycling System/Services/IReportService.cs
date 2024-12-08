using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Services
{
    public interface IReportService
    {
        public Task<WeeklyReportDto> GenerateWeeklyReport();
    }
    public class WeeklyReportDto
    {
        public List<Complaint> WeeklyComplaints { get; set; }
        public int WeeklyCollectionsCount { get; set; }
        public List<Event> WeeklyEvents { get; set; }
        public List<Training> WeeklyTrainings { get; set; }
    }
}
