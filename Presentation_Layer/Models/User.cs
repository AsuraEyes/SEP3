namespace Presentation_Layer.Models
{
    public class User
    {
        public string username{ get; set; }
        
        public string password{ get; set; }
        
        public string firstName{ get; set; }
        
        public string lastName{ get; set; }
        
        public int roleId{ get; set; }
        
        public string phoneCountryCode{ get; set; }
        
        public string phoneNumber{ get; set; }
        
        public string emailAddress{ get; set; }
        
        public bool requestedPromotion{ get; set; }
    }
}