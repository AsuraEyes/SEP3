using System;
using System.Linq;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace BankServer.MiddlePoint
{
    public class PaymentValidationMiddlePoint: IPaymentValidationMiddlePoint
    {
        public string ValidateCard(UserCardInfo userCard)
        {
            Random rand = new Random();
            userCard.AvailableSavings = rand.Next(200); 
            
            if (userCard.CardNumber.Length != 16)
            {
                return "Not a valid card. Expected 16 digits with no separation in between.";
            }
            if (!userCard.CardNumber.StartsWith("4"))
            {
                return "Not a valid VISA card.";
            } 
            if (userCard.CardHolderName.All(char.IsDigit))
            {
                return "Not a valid name.";
            }

            if (userCard.CVC.Length !=3 || !userCard.CVC.All(char.IsDigit))
            {
                return "Invalid CVC";
            }

            if (userCard.ExpiryDate.CompareTo(DateTime.Today) < 0)
            {
                return "Card expired";
            }

            if (userCard.AvailableSavings < userCard.Fee)
            {
                return "Not enough money on the card";
            }

            return "Approved";
        }
    }
}