using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace BusinessTier.MiddlePoint.FeeMiddlePoints
{
    public interface IFeeMiddlePoint
    {
        Task<string> CreateOneTimePaymentAsync(UserCardInfo userCardInfo);
        Task<string> CreateMonthlyFeeAsync(UserCardInfo userCardInfo);
        Task<bool> CheckSubscriptionAsync(string username);
    }
}