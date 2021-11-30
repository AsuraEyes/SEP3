using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Presentation_Layer.Models
{
    public class UserCardInfo
    {
        public string Username { get; set; }
        public DateTime StartDateTime { get; set; }
        public int EventId { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string CardHolderName { get; set; }
        [Required]
        public string CVC { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        
        public int AvailableSavings { get; set; }
        
        [Required]
        public int Fee { get; set; }
    }
}