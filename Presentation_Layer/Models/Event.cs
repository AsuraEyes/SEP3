#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Models
{
    public class Event
    {
        [Required]
        public int Id{ get; set; }
        
        [Required]
        public string Name{ get; set; }
        
        [Required]
        [RequiredIf("Date <= Today")]
        [AssertThat("Date > Today()", 
            ErrorMessage = "The date must be later than today")]
        public DateTime Date { get; set; }
        
        [Required]
        [AssertThat("TimeStart > Now()", 
            ErrorMessage = "The start time must be later than now.")]
        public DateTime TimeStart { get; set; }
        
        [AssertThat("TimeEnd > TimeStart", 
            ErrorMessage = "The end time must be later than the start time.")]
        public DateTime TimeEnd;

        [Required]
        [AssertThat("StarTime >= Today()")]
        public DateTime StartTime{ get; set; }
        
        [RequiredIf("EndTime <= Today()")]
        [AssertThat("endTime > startTime", 
            ErrorMessage = "The end time must be later than the start time.")] 
        public DateTime EndTime{ get; set; }
        
        [Required(ErrorMessage = "The Address Street Name is required.")]
        public string AddressStreetName{ get; set; }
        
        [Required(ErrorMessage = "The Address Street Number is required.")]
        public string AddressStreetNumber{ get; set; }
        
        public string? AddressApartmentNumber{ get; set; }
        public string Organizer { get; set; }
        
        [Required(ErrorMessage = "Max number of participants field is required.")]
        [Range(2, int.MaxValue, ErrorMessage = "Please enter a number greater than 1.")]
        public int MaxNumberOfParticipants{ get; set; }
        
        public int NumberOfParticipants{ get; set; }
        
        [Required]
        [AssertThat("EventCategory >= 1", ErrorMessage = "Select a category")]
        public int EventCategory{ get; set; }

    }
}