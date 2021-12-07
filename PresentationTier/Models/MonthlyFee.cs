using System;

namespace Presentation_Layer.Models
{
    public class MonthlyFee
    {
        public  int Id{ get; set; }
        
        public  int Amount{ get; set; }
        
        public  DateTime StartDate{ get; set; }
        
        public  DateTime EndDate{ get; set; }
        
        public  string UserUsername{ get; set; }
    }
}