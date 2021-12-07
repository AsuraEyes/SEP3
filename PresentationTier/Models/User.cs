using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Models
{
    public class User
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Username{ get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        public string Password{ get; set; }
        
        [Required(ErrorMessage = "Please confirm your password.")]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }
        
        public string? FirstName{ get; set; }
        
        public string? LastName{ get; set; }
        
        public int Role{ get; set; }
        
        public string? PhoneCountryCode{ get; set; }
        
        public string? PhoneNumber{ get; set; }
        
        public string? EmailAddress{ get; set; }
        
        public bool RequestedPromotion{ get; set; }
        public int Id { get; set; }
    }
}