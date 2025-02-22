﻿namespace Waste_Management_and_Recycling_System.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<EventVolunteer> RegisteredVolunteers { get; set; }
    }
}
