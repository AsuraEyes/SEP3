using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationTier.Models
{
    public class UserCardInfo
    {
        public string Username { get; set; }
        public DateTime StartDateTime { get; set; }
        public int EventId { get; set; }
        [Required(ErrorMessage = "Card number is required.")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Card holder name is required.")]
        public string CardHolderName { get; set; }
        [Required(ErrorMessage = "CVC is required")]
        public string CVC { get; set; }
        [Required(ErrorMessage = "Expiry date is required")]
        public DateTime ExpiryDate { get; set; }
        
        public int AvailableSavings { get; set; }
        
        [Required]
        public int Fee { get; set; }
    }
}