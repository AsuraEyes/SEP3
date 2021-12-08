using System.Threading.Tasks;
using BusinessTier.Models;

namespace BusinessTier.MiddlePoint.GameMiddlePoints.GameLists
{
    public interface IGameListMiddlePoint
    {
        Task GameListUpdate(GameListUpdate gameListUpdate);
    }
}