using System.Net.Http.Headers;

namespace SEP3_Blazor.Models
{
    public class Game: GoldenGameList
    {
        public Game()
        {
            ProductName = new Product();
        }
        
        public Product ProductName { get; set; }
    }
}