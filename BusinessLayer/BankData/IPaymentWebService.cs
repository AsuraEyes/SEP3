using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace BusinessLayer.BankData
{
    public interface IPaymentWebService
    {
        Task<string> ValidatePaymentAsync(UserCardInfo userCard);
    }
}