using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer.Data;
using BusinessLayer.Middlepoint;

namespace BusinessTierTests
{
    [TestClass]
    public class UserTest
    {
        private static readonly IUserWebService UserWebService = new UserWebService();
        private readonly IUserMiddlePoint userMiddlePoint = new UserMiddlePoint(UserWebService);
        

        [TestMethod]
        public async Task CreateAccountAsync()
        {
            try
            { 
                var newUser = new User 
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
            Assert.Fail();
        }
    }
}