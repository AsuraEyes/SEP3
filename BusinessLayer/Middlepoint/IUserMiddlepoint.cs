using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Middlepoint
{
    public interface IUserMiddlepoint
    {
        Task ValidateUserAsync(User user);
        Task<User> GetValidatedUser();
        Task CreateAccountAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
    }
}