using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waste_Management_and_Recycling_System.Models;
using Waste_Management_and_Recycling_System.Repositories;
using Waste_Management_and_Recycling_System.Services;

namespace Waste_Management_and_Recycling_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IUserRepo _userRepo;
        private readonly INotificationService _notificationService;
        public EventsController(IEventService eventService, INotificationService notificationService, IUserRepo userRepo)
        {
            _eventService = eventService;
            _notificationService = notificationService;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events= await _eventService.GetAllEvents();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventById(int eventId)
        {
            var evt = _eventService.GetEventById(eventId);
            if(evt!=null)
                return Ok(evt);
            return NotFound();
        }
        [HttpGet("volunteer/{volunteerId}")]
        public async Task<IActionResult> GetEventsByVolunteerId(int volunteerId)
        {
            var evts=await _eventService.GetEventsByVolunteerId(volunteerId);
            return Ok(evts);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddEvent([FromBody] EventDTO evtdto)
        {
            var evt = new Event
            {
                EventName = evtdto.EventName,
                Date = evtdto.Date,
                Description = evtdto.Description,
                Location = evtdto.Location,
            };
            evt.RegisteredVolunteers = new List<EventVolunteer>();
            await _eventService.AddEvent(evt);
            return CreatedAtAction(nameof(GetEventById), new { eventId = evt.EventId }, evt);
        }

        [HttpPut("{eventId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEvent(int eventId,[FromBody] EventDTO evtdto)
        {
            var evt = new Event
            {
                EventId = eventId,
                EventName = evtdto.EventName,
                Date = evtdto.Date,
                Description = evtdto.Description,
                Location = evtdto.Location,
            };
            await _eventService.UpdateEvent(evt);
            return Ok(evt);
        }

        [HttpPost("{eventId}/register/{volunteerId}")]
        [Authorize(Roles = "Volunteer")]

        public async Task<IActionResult> RegisterVolunteer(int eventId, int volunteerId)
        {
            await _eventService.RegisterVolunteer(eventId, volunteerId);
            var volunteer=_userRepo.GetUserById(volunteerId);
            var evt=_eventService.GetEventById(eventId);
            await _notificationService.SendNotification(volunteerId, volunteer.Email, volunteer.Username, "Event Registration", "You registered for an event  " + evt.EventName, "Event");
            return Ok("Volunteer registered successfully");
        }

        [HttpPost("markParticipation/{eventId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MarkParticipation(int eventId)
        {
            await _eventService.MarkParticipation(eventId);
            return Ok("Participation marked successfully");
        }
    }

    public class EventDTO
    {
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
