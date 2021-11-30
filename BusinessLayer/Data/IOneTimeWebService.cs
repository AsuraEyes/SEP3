using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IOneTimeWebService
    {
        Task createOneTimeFee(OneTimeFee oneTimeFee);
        Task<OneTimeFee> getOneTimeFee(string username, int eventId);
    }
}