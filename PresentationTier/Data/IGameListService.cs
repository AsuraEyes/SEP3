using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data
{
    public interface IGameListService
    {
        Task<IList<Game>> GetUserGamesAsync(string username);
        Task UpdateUserGamesAsync(string username, int gameId, bool inList);
        Task<IList<int>> GetUserGamesIdsAsync(string username);
    }
}