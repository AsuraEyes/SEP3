using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.FeeWebServices.OneTimeFees
{
    public interface IOneTimeFeeWebService
    {
        Task CreateOneTimeFeeAsync(OneTimeFee oneTimeFee);
        Task<OneTimeFee> GetOneTimeFeeAsync(string username, int eventId);
        Task<IList<OneTimeFee>> GetOneTimeFeeListAsync(string username);
    }
}