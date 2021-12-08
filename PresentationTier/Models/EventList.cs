using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PresentationTier.Models
{
    public class EventList
    {
        public int Count { get; set; }
        [JsonPropertyName("eventList")]
        public Event[] ListOfEvents { get; set; }

        public EventList()
        {
            ListOfEvents = new Event[] { };
        }
    }
}