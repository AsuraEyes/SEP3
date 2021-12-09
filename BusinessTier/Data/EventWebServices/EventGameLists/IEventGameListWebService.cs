using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.EventWebServices.EventGameLists
{
    public interface IEventGameListWebService
    {
        Task<IList<Game>> GetAllEventGameListAsync(int eventId);
        Task AddGameToEventGameListAsync(string username, int gameId, int eventId);
        Task RemoveGameFromEventGameListAsync(string username, int gameId, int eventId);
    }
}