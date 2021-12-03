using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;

namespace BusinessLayer.Middlepoint
{
    public class UserMiddlepoint : IUserMiddlepoint
    {
        private IUserWebService UserWebService;
        public UserMiddlepoint(IUserWebService userWebService)
        {
            UserWebService = userWebService;
        }
        
        public async Task<User> ValidateUserAsync(User user)
        {
            var userFromDatabLoggedIn = await UserWebService.GetUserAsync(user.username);
            if (userFromDatabLoggedIn == null)
            {
                return null;
            }
            if (user.password.Equals(userFromDatabLoggedIn.password))
            {
                return userFromDatabLoggedIn;
            }
            return null;
        }

        public async Task CreateAccountAsync(User user)
        {
            user.role = 2;
            await UserWebService.CreateAccountAsync(user);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await UserWebService.GetUserAsync(username);
        }

        public async Task RequestPromotionToOrganizer(string username)
        {
            User userToBePromoted = await GetUserByUsernameAsync(username);
            userToBePromoted.requestedPromotion = true;
            await UserWebService.UpdateUser(userToBePromoted);
        }

        public async Task AcceptPromotion(User user)
        {
            user.role = 3;
            user.requestedPromotion = false;
            await UserWebService.UpdateUser(user);
        }
        
        public async Task DeclinePromotion(User user)
        {
            user.requestedPromotion = false;
            await UserWebService.UpdateUser(user);
        }
    }
}