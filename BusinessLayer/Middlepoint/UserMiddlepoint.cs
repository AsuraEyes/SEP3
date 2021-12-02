using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;

namespace BusinessLayer.Middlepoint
{
    public class UserMiddlepoint : IUserMiddlepoint
    {
        private IUserWebService UserWebService;
        private User user;
        private User userFromDatabLoggedIn;

        public UserMiddlepoint(IUserWebService userWebService)
        {
            UserWebService = userWebService;
            user = null;
        }
        
        public async Task<User> ValidateUserAsync(User user)
        {
            this.user = user;
            userFromDatabLoggedIn = await UserWebService.GetUserAsync(user.username);
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
            if (username.Equals(userFromDatabLoggedIn.username))
            {
                return userFromDatabLoggedIn;
            }
            return await UserWebService.GetUserAsync(username);
        }

        public async Task RequestPromotionToOrganizer()
        {
            if (userFromDatabLoggedIn.requestedPromotion)
            {
                //don't request again
            }
            else
            {
                userFromDatabLoggedIn.requestedPromotion = true;
                Console.WriteLine("middlepoint role of user: "+userFromDatabLoggedIn.role);
                await UserWebService.UpdateUser(userFromDatabLoggedIn);
            }
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