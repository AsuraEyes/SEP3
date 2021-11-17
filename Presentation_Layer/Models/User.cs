namespace Presentation_Layer.Models
{
    public class User
    {
        public string Username{ get; set; }
        
        public string Password{ get; set; }
        
        public string FirstName{ get; set; }
        
        public string LastName{ get; set; }
        
        public int RoleId{ get; set; }
        
        public string PhoneCountryCode{ get; set; }
        
        public string PhoneNumber{ get; set; }
        
        public string EmailAddress{ get; set; }
        
        public bool RequestedPromotion{ get; set; }
    }
}