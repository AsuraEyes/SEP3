using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data
{
    public interface IPaymentService
    {
        Task<string> MonthlyPaymentAsync(UserCardInfo userCard);
        Task<string> OneTimePaymentAsync(UserCardInfo userCard);
        Task<bool> CheckSubscriptionAsync(string username);
        Task<IList<OneTimeFee>> GetOneTimePaymentListAsync(string username);
        Task<IList<MonthlyFee>> GetSubscriptionListAsync(string username);
        Task<MonthlyFee> GetSubscriptionAsync(string username);
        Task<OneTimeFee> GetEventFeeAsync(string username, int eventId);
    }
}