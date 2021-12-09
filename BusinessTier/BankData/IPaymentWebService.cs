using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace BusinessTier.BankData
{
    public interface IPaymentWebService
    {
        Task<string> ValidatePaymentAsync(UserCardInfo userCard);
    }
}