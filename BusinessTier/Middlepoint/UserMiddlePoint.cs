using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using BusinessLayer.Models;

namespace BusinessLayer.Middlepoint
{
    public class UserMiddlePoint : IUserMiddlePoint
    {
        private readonly IUserWebService userWebService;
        private int resultsPerPage = 10;
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

        public async Task<IList<User>> GetUsersAsync(FilterREST filterRest)
        {
            Filter filter = new Filter();
            if (filterRest.Search != null)
            {
                filter.filter = filterRest.Search;   
            }
            else
            {
                filter.filter = "";
            }
            filter.limit = resultsPerPage;
            filter.offset = (filterRest.CurrentPage - 1) * resultsPerPage;
            return await userWebService.GetUsersAsync(filter);
        }
    }
}