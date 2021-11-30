using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IMonthlyFeeWebService
    {
        Task createMonthlyFee(MonthlyFee monthlyFee);
        Task<MonthlyFee> getMonthlyFee(string username);
    }
}