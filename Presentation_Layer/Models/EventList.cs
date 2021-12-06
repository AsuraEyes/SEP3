using System.Collections.Generic;

namespace Presentation_Layer.Models
{
    public class EventList
    {
        public int Count { get; set; }
        public Event[] ListOfEvents { get; set; }

        public EventList()
        {
            ListOfEvents = new Event[] { };
        }
    }
}