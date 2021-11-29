using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Middlepoint
{
    public interface IGameListMiddlepoint
    {
        Task GameListUpdate(GameListUpdate gameListUpdate);
    }
}