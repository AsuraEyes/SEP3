using System.Threading.Tasks;

namespace BusinessLayer.Data
{
    public class UserService : IUserService

    {
        public async Task<string> HelloWorld()
        {
            string answer = "verified";
            ISOAPWebService webService = new SOAPWebService();
            return await webService.HelloWorld(answer);
        }
    }
}