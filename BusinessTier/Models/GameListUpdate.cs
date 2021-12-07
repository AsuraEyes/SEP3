namespace BusinessTier.Models
{
    public class GameListUpdate
    {
        public string Username { get; set; }
        public int GameId { get; set; }
        public bool InList { get; set; }
    }
}