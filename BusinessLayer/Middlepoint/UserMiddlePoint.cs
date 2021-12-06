using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;

namespace BusinessLayer.Middlepoint
{
    public class UserMiddlePoint : IUserMiddlePoint
    {
        private readonly IUserWebService userWebService;
        public UserMiddlePoint(IUserWebService userWebService)
        {
            this.userWebService = userWebService;
        }
        
        public async Task<User> ValidateUserAsync(User user)
        {
            var userFromDatabLoggedIn = await userWebService.GetUserAsync(user.username);
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
            await userWebService.CreateAccountAsync(user);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await userWebService.GetUserAsync(username);
        }

        public async Task RequestPromotionToOrganizer(string username)
        {
            User userToBePromoted = await GetUserByUsernameAsync(username);
            userToBePromoted.requestedPromotion = true;
            await userWebService.UpdateUser(userToBePromoted);
        }

        public async Task AcceptPromotion(User user)
        {
            user.role = 3;
            user.requestedPromotion = false;
            await userWebService.UpdateUser(user);
        }
        
        public async Task DeclinePromotion(User user)
        {
            user.requestedPromotion = false;
            await userWebService.UpdateUser(user);
        }
    }
}