using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;

namespace Waste_Management_and_Recycling_System.Services
{
    public class EventService: IEventService
    {
        private readonly IEventRepo _eventRepo;
        public EventService(IEventRepo eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventRepo.GetAllEvents();
        }
        public async Task<IEnumerable<EventVolunteer>> GetEventsByVolunteerId(int volunteerId)
        {
            return await _eventRepo.GetEventsByVolunteerId(volunteerId);
        }
        public Event GetEventById(int eventId)
        {
            return _eventRepo.GetEventById(eventId);
        }
        public async Task AddEvent(Event evnt)
        {
            await _eventRepo.AddEvent(evnt);
        }
        public async Task UpdateEvent(Event evnt)
        {
            await _eventRepo.UpdateEvent(evnt);
        }
        public async Task RegisterVolunteer(int eventId, int volunteerId)
        {
            await _eventRepo.RegisterVolunteer(eventId, volunteerId);
        }
        public async Task MarkParticipation(int eventId)
        {
            await _eventRepo.MarkParticipation(eventId);
        }
    }
}
