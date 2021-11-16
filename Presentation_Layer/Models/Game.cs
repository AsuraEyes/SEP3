namespace Presentation_Layer.Models
{
    public class Game
    {

        public int id{ get; set; } 
        
            public string name{ get; set; }
        
            public int complexity{ get; set; }
        
            public int timeEstimation{ get; set; }
        
            public int minNumberOfPlayers{ get; set; }
        
            public int maxNumberOfPlayers{ get; set; }
        
            public string shortDescription{ get; set; }
        
            public string neededEquipment{ get; set; }
        
            public int minAge{ get; set; }
        
            public int maxAge{ get; set; }
        
            public string tutorial{ get; set; }
        
            public bool approved{ get; set; }
    }
}