using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class UserWebService : IUserWebService

    {
        private BookAndPlayPort port;
        private SOAPUserResponse1 response;

        public UserWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPUserResponse1> getUserResponse(string username, Operation name, User User)
        {
            SOAPUserRequest soapUserRequest = new SOAPUserRequest();
            soapUserRequest.username = username;
            soapUserRequest.Operation = name;
            soapUserRequest.User = User;
            SOAPUserRequest1 soapRequest1 = new SOAPUserRequest1(soapUserRequest);
            SOAPUserResponse1 soapResponse1 = new SOAPUserResponse1();
            soapResponse1 = port.SOAPUserAsync(soapRequest1).Result;
            return soapResponse1;
        }
        public async Task<User> GetUserAsync(string username)
        {
            response = await getUserResponse(username, Operation.GET, null);
            User User = response.SOAPUserResponse.user;
            Console.WriteLine("web service: "+User.role);
            return  User;
        }

        public async Task  AddUserAsync(User user)
        {
            response = await getUserResponse("", Operation.POST, user);
            //return response.getMessageResponse.Notification;
        }
    }
}