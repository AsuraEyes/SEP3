using System.Threading.Tasks;

namespace BusinessLayer.Middlepoint
{
    public interface IGameListMiddlepoint
    {
        Task GameListUpdate(GameListUpdate gameListUpdate)
    }
}