namespace BusinessLayer.Models
{
    public class EventGameListUpdate
    {
        public string username { get; set; }
        public int gameId { get; set; }
        public int eventId { get; set; }
        public bool inList { get; set; }
    }
}