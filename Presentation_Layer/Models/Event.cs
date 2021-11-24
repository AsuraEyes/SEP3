using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Models
{
    public class Event
    {
        [Required]
        public int Id{ get; set; }
        
        [Required]public string Name{ get; set; }

        [Required]
        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime{ get; set; }

        public DateTime EndTime{ get; set; }
        
        [Required(ErrorMessage = "The Address Street Name is required.")]
        public string AddressStreetName{ get; set; }
        
        [Required(ErrorMessage = "The Address Street Number is required.")]
        public string AddressStreetNumber{ get; set; }
        
        public string AddressApartmentNumber{ get; set; }
        public string Organizer { get; set; }
        
        [Required(ErrorMessage = "Max number of participants field is required.")]
        [Range(2, int.MaxValue, ErrorMessage = "Please enter a number greater than 1.")]
        public int MaxNumberOfParticipants{ get; set; }
        
        public int NumberOfParticipants{ get; set; }
        
        [Required]public int EventCategory{ get; set; }

    }
}