using System.Threading.Tasks;

namespace DefaultNamespace
{
    public class UserService : IUserService

    {
        public async Task<string> helloWorld()
        {
            string answer = "verified";
            return await (SOAPWebService).helloWorld(answer);
        }
    }
}