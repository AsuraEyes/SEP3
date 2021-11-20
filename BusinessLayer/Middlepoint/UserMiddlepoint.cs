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
        private User userFromDatab;

        public UserMiddlepoint(IUserWebService userWebService)
        {
            UserWebService = userWebService;
            user = null;
        }
        
        public async Task ValidateUserAsync(User user)
        {
            this.user = user;
            userFromDatab = await UserWebService.GetUserAsync(user.username);
            Console.WriteLine("middlepoint: "+userFromDatab.role);
        }

        public async Task<User> GetValidatedUser()
        {
            if (userFromDatab == null)
            {
                return null;
            }
            if (user.password.Equals(userFromDatab.password))
            {
                return userFromDatab;
            }
            return null;
        }
    }
}