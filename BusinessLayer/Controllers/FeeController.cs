using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using BusinessLayer.Middlepoint;
using Microsoft.AspNetCore.Mvc;
using Presentation_Layer.Models;

namespace REST.Controllers
{
    [ApiController]
    [Route("Fee")]
    public class FeeController: Controller
    {
        private IFeeMiddlePoint feeMiddlePoint;
        private IOneTimeFeeWebService oneTimeFeeWebService;
        private IMonthlyFeeWebService monthlyFeeWebService;

        public FeeController(IFeeMiddlePoint feeMiddlePoint, IOneTimeFeeWebService oneTimeFeeWebService, IMonthlyFeeWebService monthlyFeeWebService)
        {
            this.feeMiddlePoint = feeMiddlePoint;
            this.oneTimeFeeWebService = oneTimeFeeWebService;
            this.monthlyFeeWebService = monthlyFeeWebService;
        }
        
        [HttpPost]
        [Route("OneTime")]
        public async Task<ActionResult<string>> OneTimeFeePayment([FromBody] UserCardInfo userCardInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var message = await feeMiddlePoint.CreateOneTimePaymentAsync(userCardInfo);
                return Ok(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("Subscription")]
        public async Task<ActionResult<string>> MonthlyFeePayment([FromBody] UserCardInfo userCardInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var message = await feeMiddlePoint.CreateMonthlyFeeAsync(userCardInfo);
                return Ok(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("Validate")]
        public async Task<ActionResult<bool>>
           CheckSubscriptionAsync([FromQuery] string username)
        {
            try
            {
                var message = await feeMiddlePoint.CheckSubscriptionAsync(username);
                return Ok(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("OneTimeHistory")]
        public async Task<ActionResult<IList<OneTimeFee>>>
            GetOneTimeFeeListAsync([FromQuery] string username)
        {
            try
            {
                IList<OneTimeFee> oneTimeFees = await oneTimeFeeWebService.GetOneTimeFeeList(username);
                return Ok(oneTimeFees);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("MonthlyHistory")]
        public async Task<ActionResult<IList<MonthlyFee>>>
            GetMonthlyFeeListAsync([FromQuery] string username)
        {
            try
            {
                IList<MonthlyFee> monthlyFees = await monthlyFeeWebService.GetMonthlyFeeList(username);
                return Ok(monthlyFees);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("Subscription")]
        public async Task<ActionResult<MonthlyFee>>
            GetMonthlyFeeAsync([FromQuery] string username)
        {
            try
            {
                MonthlyFee monthlyFees = await monthlyFeeWebService.GetMonthlyFee(username);
                return Ok(monthlyFees);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}