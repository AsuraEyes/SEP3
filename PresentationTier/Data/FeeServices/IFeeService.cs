using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.FeeServices
{
    public interface IFeeService
    {
        Task<string> SubscribeAsync(UserCardInfo userCard);
        Task<string> OneTimeFeeAsync(UserCardInfo userCard);
        Task<bool> CheckSubscriptionAsync(string username);
        Task<IList<OneTimeFee>> GetOneTimeFeeListAsync(string username);
        Task<IList<MonthlyFee>> GetSubscriptionListAsync(string username);
        Task<MonthlyFee> GetSubscriptionAsync(string username);
        Task<OneTimeFee> GetEventFeeAsync(string username, int eventId);
    }
}