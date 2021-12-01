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
        
        public async Task ValidateUserAsync(User user)
        {
            this.user = user;
            userFromDatabLoggedIn = await UserWebService.GetUserAsync(user.username);
            Console.WriteLine("middlepoint: "+userFromDatabLoggedIn.role+" username: "+userFromDatabLoggedIn.username + " password: "+userFromDatabLoggedIn.password);
        }

        public async Task<User> GetValidatedUser()
        {
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
            else
            {
                return await UserWebService.GetUserAsync(username);
            }
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
                await UserWebService.RequestPromotionToOrganizer(userFromDatabLoggedIn);
            }
        }
    }
}