using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Middlepoint
{
    public interface IGameMiddlepoint
    {
        Task AddGameAsync(Game game);
    }
}