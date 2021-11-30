using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IMonthlyFeeWebService
    {
        Task CreateMonthlyFee(MonthlyFee monthlyFee);
        Task<MonthlyFee> GetMonthlyFee(string username);
        Task<IList<MonthlyFee>> GetMonthlyFeeList(string username);
        Task UpdateMonthlyFee(MonthlyFee monthlyFee);
    }
}