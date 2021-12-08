using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.GameWebServices.Games
{
    public interface IGameWebService
    {
        Task<Game> GetGameAsync(int id);
        Task SuggestGameAsync(Game game);
        Task<IList<Game>> GetSuggestedGamesAsync();

        Task<IList<Game>> GetLimitedSearchGamesAsync(Filter filter);
        Task RemoveGameAsync(int id);
        Task EditGameAsync(Game game);
    }
}