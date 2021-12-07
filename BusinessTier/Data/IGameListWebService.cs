using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IGameListWebService
    {
        Task<IList<Game>> GetUserGameListAsync(string user);
        Task AddGameToUserGameListAsync(string username, int gameId);
        Task RemoveGameFromUserGameListAsync(string username, int gameId);
    }
}