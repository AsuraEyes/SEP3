using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface IPaymentService
    {
        Task<string> MonthlyPaymentAsync(UserCardInfo userCard);
        Task<string> OneTimePaymentAsync(UserCardInfo userCard);
        Task<bool> CheckSubscription(string username);
    }
}