using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Middlepoint
{
    public interface IEventGameListMiddlePoint
    {
        Task EventGameListUpdateAsync(EventGameListUpdate eventGameListUpdate);
    }
}