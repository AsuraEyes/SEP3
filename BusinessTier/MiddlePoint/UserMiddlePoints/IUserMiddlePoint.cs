using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Models;

namespace BusinessTier.MiddlePoint.UserMiddlePoints
{
    public interface IUserMiddlePoint
    {
        Task<User> ValidateUserAsync(User user);
        Task CreateAccountAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task RequestPromotionToOrganizer(string username);
        Task AcceptPromotion(string username);
        Task DeclinePromotion(string username);
        Task<IList<User>> GetUsersAsync(FilterRest filterRest);
    }
}