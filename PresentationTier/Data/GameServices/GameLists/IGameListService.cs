using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.GameServices.GameLists
{
    public interface IGameListService
    {
        Task<IList<Game>> GetUserGamesAsync(string username);
        Task EditUserGamesAsync(string username, int gameId, bool inList);
        Task<IList<int>> GetUserGamesIdsAsync(string username);
    }
}