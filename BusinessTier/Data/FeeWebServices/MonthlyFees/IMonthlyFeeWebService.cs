using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessTier.Data.FeeWebServices.MonthlyFees
{
    public interface IMonthlyFeeWebService
    {
        Task CreateMonthlyFeeAsync(BookAndPlaySOAP.MonthlyFee monthlyFee);
        Task<BookAndPlaySOAP.MonthlyFee> GetMonthlyFeeAsync(string username);
        Task<IList<BookAndPlaySOAP.MonthlyFee>> GetMonthlyFeeListAsync(string username);
        Task UpdateMonthlyFeeAsync(BookAndPlaySOAP.MonthlyFee monthlyFee);
    }
}