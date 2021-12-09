using System.Threading.Tasks;
using BusinessTier.Models;

namespace BusinessTier.MiddlePoint.EventMiddlePoints.EventGameLists
{
    public interface IEventGameListMiddlePoint
    {
        Task EventGameListUpdateAsync(EventGameListUpdate eventGameListUpdate);
    }
}