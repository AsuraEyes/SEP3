using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface ISOAPGame
    {
        Task<Game> GetGameAsync(int id);
        Task AddGameAsync(Game Game);
        Task<IList<Game>> GetGamesAsync();
        Task RemoveGameAsync(Game Game);
        Task UpdateGameAsync(Game Game);
    }
}