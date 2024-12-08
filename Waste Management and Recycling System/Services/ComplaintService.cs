using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;

namespace Waste_Management_and_Recycling_System.Services
{
    public class ComplaintService: IComplaintService
    {
        private readonly IComplaintRepo _complaintRepo;
        public ComplaintService(IComplaintRepo complaintRepo)
        {
            _complaintRepo = complaintRepo;
        }
        public async Task AddComplaint(Complaint complaint)
        {
            await _complaintRepo.AddComplaint(complaint);
        }
        public async Task<IEnumerable<Complaint>> GetAllComplaints()
        {
            return await _complaintRepo.GetAllComplaints();
        }
        public async Task<IEnumerable<Complaint>> GetComplaintsByStatus(string status)
        {
            return await _complaintRepo.GetComplaintsByStatus(status);
        }
        public async Task<IEnumerable<Complaint>> GetComplaintsByResidentId(int residentId)
        {
            return await _complaintRepo.GetComplaintsByResidentId(residentId);
        }
        public async Task<IEnumerable<Complaint>> GetComplaintsByResidentIdAndStatus(int residentId, string status)
        {
            return await _complaintRepo.GetComplaintsByResidentIdAndStatus(residentId, status);
        }
        public Complaint GetComplaintById(int complaintId)
        {
            return _complaintRepo.GetComplaintById(complaintId);
        }
        public async Task UpdateComplaintStatus(int complaintId, string resolutionStatus)
        {
            await _complaintRepo.UpdateComplaintStatus(complaintId, resolutionStatus);
        }
        public async Task DeleteComplaint(int complaintId)
        {
            await _complaintRepo.DeleteComplaint(complaintId);
        }
    }
}
