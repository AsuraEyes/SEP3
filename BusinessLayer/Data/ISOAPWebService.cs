using System.Net;
using System.Threading.Tasks;

namespace BusinessLayer.Data
{
    public interface ISOAPWebService
    {
        Task Execute();
        Task<HttpWebRequest> GetWebRequest();
        Task<string> HelloWorld(string param);
    }
}