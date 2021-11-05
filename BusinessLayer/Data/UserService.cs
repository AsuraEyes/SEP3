using System.Threading.Tasks;

namespace BusinessLayer.Data
{
    public class UserService : IUserService

    {
        public async Task<string> HelloWorld()
        {
            
            ISOAPWebService webService = new SOAPWebService();
            return await webService.HelloWorld();
        }
    }
}