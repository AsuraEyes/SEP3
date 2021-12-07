using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Middlepoint
{
    public interface IGameListMiddlePoint
    {
        Task GameListUpdate(GameListUpdate gameListUpdate);
    }
}