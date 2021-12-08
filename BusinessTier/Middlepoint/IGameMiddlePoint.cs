using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Models;

namespace BusinessTier.Middlepoint
{
    public interface IGameMiddlePoint
    {
        Task AddGameAsync(Game game);
        Task<IList<int>> GetUserGamesIdsAsync(string user);
        Task UpdateGameApprovalAsync(Game game);
        Task<IList<Game>> GetLimitedSearchGGLAsync(FilterREST filterRest);
    }
}