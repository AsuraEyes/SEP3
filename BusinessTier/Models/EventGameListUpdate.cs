namespace BusinessLayer.Models
{
    public class EventGameListUpdate
    {
        public string Username { get; set; }
        public int GameId { get; set; }
        public int EventId { get; set; }
        public bool InList { get; set; }
    }
}