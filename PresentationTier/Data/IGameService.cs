using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface IGameService
    {
        Task<Game> GetGameAsync(int id);
        Task SuggestGameAsync(Game Game);
        Task RemoveGameAsync(Game game);
        Task UpdateGameApprovalAsync(Game game);
        Task CreateGameAsync(Game Game);
        Task<IList<Game>> GetGGLAsync();
        Task<IList<Game>> GetSuggestedGamesAsync();
        Task EditGameAsync(Game game);
    }
}