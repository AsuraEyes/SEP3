using System;

namespace Presentation_Layer.Models
{
    public class Event
    {
        public int Id{ get; set; }
        
        public string Name{ get; set; }
        
        public DateTime StartTime{ get; set; }
        
        public DateTime EndTime{ get; set; }
        
        public string AddressStreetName{ get; set; }
        
        public string AddressStreetNumber{ get; set; }
        
        public string AddressApartmentNumber{ get; set; }
        
        public int MaxNumberOfParticipants{ get; set; }
        
        public int NumberOfParticipants{ get; set; }
        
        public string EventCategory{ get; set; }

    }
}