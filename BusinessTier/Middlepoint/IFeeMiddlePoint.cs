using System.Threading.Tasks;
using BookAndPlaySOAP;
using Presentation_Layer.Models;

namespace BusinessLayer.Middlepoint
{
    public interface IFeeMiddlePoint
    {
        Task<string> CreateOneTimePaymentAsync(UserCardInfo userCardInfo);
        Task<string> CreateMonthlyFeeAsync(UserCardInfo userCardInfo);
        Task<bool> CheckSubscriptionAsync(string username);
    }
}