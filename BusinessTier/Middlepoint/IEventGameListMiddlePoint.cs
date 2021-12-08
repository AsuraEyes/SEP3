using System.Threading.Tasks;
using BusinessTier.Models;

namespace BusinessTier.Middlepoint
{
    public interface IEventGameListMiddlePoint
    {
        Task EventGameListUpdateAsync(EventGameListUpdate eventGameListUpdate);
    }
}