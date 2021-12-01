using System;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.BankData;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Diagnostics;
using Presentation_Layer.Models;

namespace BusinessLayer.Middlepoint
{
    public class FeeMiddlePoint : IFeeMiddlePoint
    {
        private IPaymentWebService paymentWebService;
        private IMonthlyFeeWebService monthlyFeeWebService;
        private IOneTimeFeeWebService oneTimeFeeWebService;
        private int monthlyFee = 120;
        private int oneTimeFee = 50;
        

        public FeeMiddlePoint(IPaymentWebService paymentWebService, IMonthlyFeeWebService monthlyFeeWebService,
            IOneTimeFeeWebService oneTimeFeeWebService)
        {
            this.paymentWebService = paymentWebService;
            this.monthlyFeeWebService = monthlyFeeWebService;
            this.oneTimeFeeWebService = oneTimeFeeWebService;
        }

        private async Task<string> ApprovePaymentAsync(UserCardInfo userCardInfo)
        {
            return await paymentWebService.ValidatePaymentAsync(userCardInfo);
        }

        public async Task<string> CreateOneTimePaymentAsync(UserCardInfo userCardInfo)
        {
            userCardInfo.Fee = oneTimeFee;

            var message = await ApprovePaymentAsync(userCardInfo);
            
            if (message.Equals("Approved"))
            {
                OneTimeFee oneTimeFee = new OneTimeFee()
                {
                    amount = userCardInfo.Fee,
                    eventId = userCardInfo.EventId,
                    userUsername = userCardInfo.Username
                };
                await oneTimeFeeWebService.CreateOneTimeFee(oneTimeFee);
            }

            return message;
        }

        public async Task<string> CreateMonthlyFeeAsync(UserCardInfo userCardInfo)
        {
            userCardInfo.Fee = monthlyFee;
            
            var message = await ApprovePaymentAsync(userCardInfo);
            
            if (message.Equals("Approved"))
            {
                if (userCardInfo.StartDateTime.Equals(DateTime.Today))
                {
                    var monthlyFee = new MonthlyFee
                    {
                        amount = userCardInfo.Fee,
                        startDate = userCardInfo.StartDateTime,
                        endDate = userCardInfo.StartDateTime.AddDays(30),
                        userUsername = userCardInfo.Username
                    };
                    await monthlyFeeWebService.CreateMonthlyFee(monthlyFee);
                }
                else
                {
                    var monthlyFee = await monthlyFeeWebService.GetMonthlyFee(userCardInfo.Username);
                    
                    DateTime endDate = monthlyFee.endDate;
                    monthlyFee.amount += userCardInfo.Fee;
                    monthlyFee.endDate = endDate.AddDays(30);
                    
                    await monthlyFeeWebService.UpdateMonthlyFee(monthlyFee);
                }

            }
            return message;
        }

        public async Task<bool> CheckSubscriptionAsync(string username)
        {
            var monthlyFee = await monthlyFeeWebService.GetMonthlyFee(username);
            if (monthlyFee != null)
            {
                if (monthlyFee.endDate.CompareTo(DateTime.Today) > 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}