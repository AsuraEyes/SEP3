using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Models;

namespace BusinessTier.MiddlePoint.GameMiddlePoints.Games
{
    public interface IGameMiddlePoint
    {
        Task AddGameAsync(Game game);
        Task<IList<int>> GetUserGamesIdsAsync(string user);
        Task EditGameApprovalAsync(Game game);
        Task<IList<Game>> GetLimitedSearchGglAsync(FilterRest filterRest);
    }
}