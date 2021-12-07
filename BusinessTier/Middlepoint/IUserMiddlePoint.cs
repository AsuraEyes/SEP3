using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Models;

namespace BusinessTier.Middlepoint
{
    public interface IUserMiddlePoint
    {
        Task<User> ValidateUserAsync(User user);
        Task CreateAccountAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task RequestPromotionToOrganizer(string username);
        Task AcceptPromotion(User user);
        Task DeclinePromotion(User user);
        Task<IList<User>> GetUsersAsync(FilterREST filterRest);
    }
}