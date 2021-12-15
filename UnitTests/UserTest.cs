using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.UserWebServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessTier.MiddlePoint.UserMiddlePoints;
using BusinessTier.Models;

namespace BusinessTierTests
{
    [TestClass]
    public class UserTest
    {
        private static readonly IUserWebService UserWebService = new UserWebService();
        private readonly IUserMiddlePoint userMiddlePoint = new UserMiddlePoint(UserWebService);
        

        [TestMethod]
        public async Task FailCreateAccountAsync()
        {
            //Fails because the username is already taken
            User newUser;
            try
            { 
                newUser = new User 
                {
                username = "boardgameGeek",
                password = "1x2y3z"
                };
                await userMiddlePoint.CreateAccountAsync(newUser);
            }
            catch (AggregateException)
            {
                return;
            }
            catch (FaultException)
            {
                return;
            }
            Assert.Fail();
        }
        
        [TestMethod]
        public async Task CreateAccountSuccessfullyAsync()
        {
            User newUser;
            User userCheck;
            try
            { 
                newUser = new User 
                {
                    username = "bobson",
                    password = "1x2y3z"
                };
                await userMiddlePoint.CreateAccountAsync(newUser);

                userCheck = await userMiddlePoint.GetUserByUsernameAsync(newUser.username);
            }
            catch (AggregateException)
            {
                return;
            }
            catch (FaultException)
            {
                return;
            }
            Assert.AreEqual(newUser, userCheck);
        }
        
        [TestMethod]
        public async Task GetAllUsersAsync()
        {
            IList<User> expectedUsers;
            IList<User> actualUsers;
            try
            {
                var allUsers = new Filter();
                var filteredUsers = new FilterRest();
            
                expectedUsers = await userMiddlePoint.GetUsersAsync(filteredUsers);
                actualUsers = await UserWebService.GetUsersAsync(allUsers);
            }
            catch (FaultException)
            {
                return;
            }
            Assert.AreEqual(expectedUsers, actualUsers);
        }
    }
}