namespace SEP3_Blazor.Models
{
    public class GoldenGameList
    {
        
        public int Id { get; set; }
        public int ComplexityLevel { get; set; }
        public int TimeEstimation { get; set; }
        public int NoPlayers { get; set; }
        public string Description { get; set; }
        public int AgeTarget { get; set; }
        public string LinkTutorialGame { get; set; }
        public string NeededEquipment { get; set; }
        public Event EventName { get; set; }
        public string Name { get; set; }
    }
}