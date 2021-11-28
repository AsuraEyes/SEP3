using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface IGameListService
    {
        Task<IList<Game>> GetUserGamesAsync(string username);
        Task UpdateUserGamesAsync(string username, int gameId, bool inList);
    }
}