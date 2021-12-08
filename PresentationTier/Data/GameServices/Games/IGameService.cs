using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.GameServices.Games
{
    public interface IGameService
    {
        Task<Game> GetGameAsync(int id);
        Task SuggestGameAsync(Game Game);
        Task RemoveGameAsync(Game game);
        Task UpdateGameApprovalAsync(Game game);
        Task CreateGameAsync(Game Game);
        Task<IList<Game>> GetSuggestedGamesAsync();
        Task EditGameAsync(Game game);
        Task<IList<Game>> GetLimitedSearchGGLAsync(FilterREST filterRest);
    }
}