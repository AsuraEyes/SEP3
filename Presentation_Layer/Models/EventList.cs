using System.Collections.Generic;

namespace Presentation_Layer.Models
{
    public class EventList
    {
        public int NumberOfPages { get; set; }
        public Event[] eventList { get; set; }

        public  EventList()
        {
            eventList = new Event[] { };
        }
    }
}