namespace Presentation_Layer.Models
{
    public class Game
    {

        public int Id{ get; set; } 
        
            public string Name{ get; set; }
        
            public int Complexity{ get; set; }
        
            public int TimeEstimation{ get; set; }
        
            public int MinNumberOfPlayers{ get; set; }
        
            public int MaxNumberOfPlayers{ get; set; }
        
            public string ShortDescription{ get; set; }
        
            public string NeededEquipment{ get; set; }
        
            public int MinAge{ get; set; }
        
            public int MaxAge{ get; set; }
        
            public string Tutorial{ get; set; }
        
            public bool Approved{ get; set; }
    }
}