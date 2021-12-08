using System.Threading.Tasks;
using BusinessTier.Models;

namespace BusinessTier.Middlepoint
{
    public interface IGameListMiddlePoint
    {
        Task GameListUpdate(GameListUpdate gameListUpdate);
    }
}