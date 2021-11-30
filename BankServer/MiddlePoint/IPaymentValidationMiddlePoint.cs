using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace BankServer.MiddlePoint
{
    public interface IPaymentValidationMiddlePoint
    {
        Task<string> ValidateCard(UserCardInfo userCard);
    }
}