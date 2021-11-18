using System;

namespace Presentation_Layer.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public int CategoryId { get; set; }

    }
}