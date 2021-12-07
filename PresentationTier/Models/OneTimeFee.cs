namespace PresentationTier.Models
{
    public class OneTimeFee
    {
        public int Id{ get; set; }
        
        public int Amount{ get; set; }
        
        public int EventId{ get; set; }
        
        public string UserUsername{ get; set; }
    }
}