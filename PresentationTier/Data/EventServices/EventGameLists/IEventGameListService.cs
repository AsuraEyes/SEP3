using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.EventServices.EventGameLists
{
    public interface IEventGameListService
    {
        Task<IList<Game>> GetAllEventGameListAsync(int id);
        Task UpdateEventGamesAsync(string username, int gameId, int eventId, bool inList);
    }
}