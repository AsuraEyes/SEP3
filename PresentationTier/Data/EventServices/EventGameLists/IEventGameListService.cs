using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.EventServices.EventGameLists
{
    public interface IEventGameListService
    {
        Task<IList<Game>> GetAllEventGameListAsync(int id);
        Task EditEventGamesAsync(string username, int gameId, int eventId, bool inList);
    }
}