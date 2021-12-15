using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.UserWebServices
{
    public class UserWebService : IUserWebService

    {
        private readonly BookAndPlayPort port;
        private SOAPUserResponse1 response;

        public UserWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPUserResponse1> GetUserResponseAsync(string username, Operation name, User thisUser, Filter filter)
        {
            var soapUserRequest = new SOAPUserRequest
            {
                username = username,
                Operation = name,
                User = thisUser,
                Filter = filter
            };
            var soapRequest1 = new SOAPUserRequest1(soapUserRequest);
            var soapResponse1 = await port.SOAPUserAsync(soapRequest1);
            return soapResponse1;
        }
        public async Task<User> GetUserAsync(string username)
        {
            response = await GetUserResponseAsync(username, Operation.GET, null, null);
            var user = response.SOAPUserResponse.user;
            return  user;
        }

        public async Task CreateAccountAsync(User user)
        {
            response = await GetUserResponseAsync("", Operation.CREATE, user, null);
        }

        public async Task DeleteAccountAsync(string username)
        {
            response = await GetUserResponseAsync(username, Operation.REMOVE,null, null);
        }

        public async Task UpdateUser(User user)
        {
            await GetUserResponseAsync("", Operation.UPDATE, user, null);
        }

        public async Task<IList<User>> GetUsersAsync(Filter filter)
        {
            response = await GetUserResponseAsync("", Operation.GETALL, null, filter);
            return response.SOAPUserResponse.userList;
        }
    }
}