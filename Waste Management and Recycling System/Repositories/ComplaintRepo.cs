using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public class ComplaintRepo:IComplaintRepo
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public ComplaintRepo(WasteManagementandRecyclingDbContext context)
        {
            _context = context;
        }
        public async Task AddComplaint(Complaint complaint)
        {
            await _context.Complaints.AddAsync(complaint);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Complaint>> GetAllComplaints()
        {
            return await _context.Complaints.ToListAsync();
        }
        public async Task<IEnumerable<Complaint>> GetComplaintsByStatus(string status)
        {
            return await _context.Complaints.Where(c=>c.ResolutionStatus == status).ToListAsync();
        }
        public async Task<IEnumerable<Complaint>> GetComplaintsByResidentId(int residentId)
        {
            return await _context.Complaints.Where(c=>c.UserId == residentId).ToListAsync();
        }
        public async Task<IEnumerable<Complaint>> GetComplaintsByResidentIdAndStatus(int residentId, string status)
        {
            return await _context.Complaints.Where(c=>c.UserId==residentId && c.ResolutionStatus==status).ToListAsync();
        }
        public Complaint GetComplaintById(int complaintId)
        {
            return _context.Complaints.FirstOrDefault(c => c.ComplaintId == complaintId);
        }
        public async Task UpdateComplaintStatus(int complaintId, string resolutionStatus)
        {
            var complaint = await _context.Complaints.FindAsync(complaintId);
            if (complaint != null)
            {
                complaint.ResolutionStatus = resolutionStatus;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteComplaint(int complaintId)
        {
            var complaint = await _context.Complaints.FindAsync(complaintId);
            if(complaint != null)
            {
                _context.Complaints.Remove(complaint);
                await _context.SaveChangesAsync();
            }
        }
    }
}
