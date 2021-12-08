using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.UserServices
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string password);
        Task<string> CreateAccountAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task RequestPromotionToOrganizerAsync(string username);
        Task AcceptPromotionAsync(User user);
        Task DeclinePromotionAsync(User user);
        Task DeleteAccountAsync(string username);
        Task<IList<User>> GetUsersAsync(FilterREST filterRest);
        Task EditAccountAsync(User user);
    }
}