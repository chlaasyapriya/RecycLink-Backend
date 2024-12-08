using Microsoft.EntityFrameworkCore;
using Waste_Management_and_Recycling_System.Data;
using Waste_Management_and_Recycling_System.Models;

namespace Waste_Management_and_Recycling_System.Repositories
{
    public class EventRepo: IEventRepo
    {
        private readonly WasteManagementandRecyclingDbContext _context;
        public EventRepo(WasteManagementandRecyclingDbContext context)
        {
              _context = context;
        }
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.Include(e => e.RegisteredVolunteers).ToListAsync();
        }
        public async Task<IEnumerable<EventVolunteer>> GetEventsByVolunteerId(int volunteerId)
        {
            return await _context.EventVolunteers.Where(e => e.VolunteerId == volunteerId).ToListAsync();
        }
        public Event GetEventById(int eventId)
        {
            return _context.Events.Include(e => e.RegisteredVolunteers).FirstOrDefault(e => e.EventId == eventId);
        }
        public async Task AddEvent(Event evnt)
        {
            await _context.Events.AddAsync(evnt);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateEvent(Event evnt)
        {
            _context.Events.Update(evnt);
            await _context.SaveChangesAsync();
        }
        public async  Task RegisterVolunteer(int eventId, int volunteerId)
        {
            var evt=_context.Events.FirstOrDefault(e=>e.EventId == eventId);
            var vol=_context.Users.FirstOrDefault(v=>v.UserId== volunteerId);
            var eventVolunteer = new EventVolunteer { EventId = eventId, Event=evt, VolunteerId = volunteerId,Volunteer=vol, HasParticipated = false };
            _context.EventVolunteers.Add(eventVolunteer);
            await _context.SaveChangesAsync();
        }
        public async Task MarkParticipation(int eventId)
        {
            var eventVolunteers =await  _context.EventVolunteers.Where(ev => ev.EventId == eventId).ToListAsync();
            if (eventVolunteers != null)
            {
                foreach (var eventVolunteer in eventVolunteers) {
                    eventVolunteer.HasParticipated = true;
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
