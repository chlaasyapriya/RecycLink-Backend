using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public interface IEventRepo
    {
        public Task<IEnumerable<Event>> GetAllEvents();
        public Task<IEnumerable<EventVolunteer>> GetEventsByVolunteerId(int volunteerId);
        public Event GetEventById(int eventId);
        public Task AddEvent(Event evnt);
        public Task UpdateEvent(Event evnt);
        public Task RegisterVolunteer(int eventId, int volunteerId);
        public Task MarkParticipation(int eventId);
    }
}
