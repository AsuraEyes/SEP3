using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.FeeWebServices.MonthlyFees
{
    public interface IMonthlyFeeWebService
    {
        Task CreateMonthlyFeeAsync(MonthlyFee monthlyFee);
        Task<MonthlyFee> GetMonthlyFeeAsync(string username);
        Task<IList<MonthlyFee>> GetMonthlyFeeListAsync(string username);
        Task UpdateMonthlyFeeAsync(MonthlyFee monthlyFee);
    }
}