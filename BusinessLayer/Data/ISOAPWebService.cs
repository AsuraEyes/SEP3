using System.Net;
using System.Threading.Tasks;

namespace BusinessLayer.Data
{
    public interface ISOAPWebService
    {
        Task<string> HelloWorld();
    }
}