using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessTier.Data.FeeWebServices.OneTimeFees
{
    public interface IOneTimeFeeWebService
    {
        Task CreateOneTimeFeeAsync(BookAndPlaySOAP.OneTimeFee oneTimeFee);
        Task<BookAndPlaySOAP.OneTimeFee> GetOneTimeFeeAsync(string username, int eventId);
        Task<IList<BookAndPlaySOAP.OneTimeFee>> GetOneTimeFeeListAsync(string username);
    }
}