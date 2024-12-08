using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public interface IComplaintRepo
    {
        public Task AddComplaint(Complaint complaint);
        public Task<IEnumerable<Complaint>> GetAllComplaints();
        public Task<IEnumerable<Complaint>> GetComplaintsByStatus(string status);
        public Task<IEnumerable<Complaint>> GetComplaintsByResidentId(int residentId);
        public Task<IEnumerable<Complaint>> GetComplaintsByResidentIdAndStatus(int residentId, string status);
        public Complaint GetComplaintById(int complaintId);
        public Task UpdateComplaintStatus(int complaintId, string resolutionStatus);
        public Task DeleteComplaint(int complaintId);
    }
}
