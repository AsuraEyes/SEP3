using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Models
{
    public class Event
    {
        [Required]
        public int Id{ get; set; }
        
        [Required]public string Name{ get; set; }
        
        [Required]public DateTime StartTime{ get; set; }
        
        public DateTime EndTime{ get; set; }
        
        [Required]public string AddressStreetName{ get; set; }
        
        [Required]public string AddressStreetNumber{ get; set; }
        
        public string AddressApartmentNumber{ get; set; }
        
        [Required]public int MaxNumberOfParticipants{ get; set; }
        
        [Required]public int NumberOfParticipants{ get; set; }
        
        [Required]public int EventCategory{ get; set; }

    }
}