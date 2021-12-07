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
        private readonly IPaymentWebService paymentWebService;
        private readonly IMonthlyFeeWebService monthlyFeeWebService;
        private readonly IOneTimeFeeWebService oneTimeFeeWebService;
        private readonly IParticipantWebService participantWebService;
        private const int MonthlyFee = 120;
        private const int OneTimeFee = 50;
        

        public FeeMiddlePoint(IPaymentWebService paymentWebService, IMonthlyFeeWebService monthlyFeeWebService,
            IOneTimeFeeWebService oneTimeFeeWebService, IParticipantWebService participantWebService)
        {
            this.paymentWebService = paymentWebService;
            this.monthlyFeeWebService = monthlyFeeWebService;
            this.oneTimeFeeWebService = oneTimeFeeWebService;
            this.participantWebService = participantWebService;
        }

        private async Task<string> ApprovePaymentAsync(UserCardInfo userCardInfo)
        {
            return await paymentWebService.ValidatePaymentAsync(userCardInfo);
        }

        public async Task<string> CreateOneTimePaymentAsync(UserCardInfo userCardInfo)
        {
            userCardInfo.Fee = OneTimeFee;

            var message = await ApprovePaymentAsync(userCardInfo);
            
            if (message.Equals("Approved"))
            {
                OneTimeFee oneTimeFee = new OneTimeFee
                {
                    amount = userCardInfo.Fee,
                    eventId = userCardInfo.EventId,
                    userUsername = userCardInfo.Username
                };
                await oneTimeFeeWebService.CreateOneTimeFeeAsync(oneTimeFee);
                await participantWebService.JoinEventAsync(userCardInfo.EventId, userCardInfo.Username);
            }

            return message;
        }

        public async Task<string> CreateMonthlyFeeAsync(UserCardInfo userCardInfo)
        {
            userCardInfo.Fee = MonthlyFee;
            
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
                    await monthlyFeeWebService.CreateMonthlyFeeAsync(monthlyFee);
                }
                else
                {
                    var monthlyFee = await monthlyFeeWebService.GetMonthlyFeeAsync(userCardInfo.Username);
                    
                    DateTime endDate = monthlyFee.endDate;
                    monthlyFee.amount += userCardInfo.Fee;
                    monthlyFee.endDate = endDate.AddDays(30);
                    
                    await monthlyFeeWebService.UpdateMonthlyFeeAsync(monthlyFee);
                }

            }
            return message;
        }

        public async Task<bool> CheckSubscriptionAsync(string username)
        {
            var monthlyFee = await monthlyFeeWebService.GetMonthlyFeeAsync(username);
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