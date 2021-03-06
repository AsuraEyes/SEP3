#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;

namespace PresentationTier.Models
{
    public class Event
    {
        [Required]
        public int Id{ get; set; }
        
        [Required]
        public string Name{ get; set; }
        
        [Required]
        [AssertThat("Date > Today()", 
            ErrorMessage = "The date must be later than today")]
        public DateTime Date { get; set; }
        
        [Required]
        public DateTime Start { get; set; }
        
        [Required]
        [AssertThat("End > Start", 
            ErrorMessage = "The end time must be later than the start time.")]
        public DateTime End { get; set; }
        
        public DateTime StartTime{ get; set; }
        
        public DateTime EndTime{ get; set; }
        
        [Required(ErrorMessage = "The Address Street Name is required.")]
        public string AddressStreetName{ get; set; }
        
        [Required(ErrorMessage = "The Address Street Number is required.")]
        public string AddressStreetNumber{ get; set; }
        
        public string? AddressApartmentNumber{ get; set; }
        public string Organizer { get; set; }
        
        [Required(ErrorMessage = "Max number of participants field is required.")]
        [Range(2, int.MaxValue, ErrorMessage = "Please enter a number of participants greater than 1.")]
        public int MaxNumberOfParticipants{ get; set; }
        
        public int NumberOfParticipants{ get; set; }
        
        [Required]
        [AssertThat("EventCategory >= 1", ErrorMessage = "Select a category")]
        public int EventCategory{ get; set; }
    }
}