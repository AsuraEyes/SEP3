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
            Console.WriteLine("in the begininging");
            if (userFromDatabLoggedIn == null)
            {
                Console.WriteLine("returns null here 1");
                return null;
            }
            if (user.password.Equals(userFromDatabLoggedIn.password))
            {
                Console.WriteLine("should return okay");
                return userFromDatabLoggedIn;
            }

            Console.WriteLine("returns null here 2");
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
    }
}