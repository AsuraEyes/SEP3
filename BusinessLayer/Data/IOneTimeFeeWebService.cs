using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IOneTimeFeeWebService
    {
        Task CreateOneTimeFee(OneTimeFee oneTimeFee);
        Task<OneTimeFee> GetOneTimeFee(string username, int eventId);
        Task<IList<OneTimeFee>> GetOneTimeFeeList(string username);
    }
}