using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Middlepoint
{
    public interface IUserMiddlepoint
    {
        Task<User> ValidateUserAsync(User user);
        Task CreateAccountAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task RequestPromotionToOrganizer();
    }
}