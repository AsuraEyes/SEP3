using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Middlepoint
{
    public interface IGameMiddlePoint
    {
        Task AddGameAsync(Game game);
        Task<IList<Game>> GetGGLAsync();
        Task<IList<Game>> GetSuggestedGamesAsync();
        Task<IList<int>> GetUserGamesIdsAsync(string user);
        Task UpdateGameApprovalAsync(Game game);
    }
}