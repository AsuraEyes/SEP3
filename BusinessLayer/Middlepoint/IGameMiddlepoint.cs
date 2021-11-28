using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Middlepoint
{
    public interface IGameMiddlepoint
    {
        Task AddGameAsync(Game game);
        Task<IList<Game>> GetGGLAsync();
        Task<IList<Game>> GetSuggestedGamesAsync();
    }
}