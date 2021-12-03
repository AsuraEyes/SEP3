using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
        Task<string> CreateAccountAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task RequestPromotionToOrganizer(string username);
        Task AcceptPromotion(User user);
        Task DeclinePromotion(User user);
        Task DeleteAccountAsync(string username);
        Task<IList<User>> GetUsersAsync();
        Task EditAccountAsync(User user);
    }
}