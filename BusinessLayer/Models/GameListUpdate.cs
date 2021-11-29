namespace BusinessLayer.Models
{
    public class GameListUpdate
    {
        public string username { get; set; }
        public int gameId { get; set; }
        public bool inList { get; set; }
    }
}