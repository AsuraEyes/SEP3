using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data;
using BusinessTier.Middlepoint;
using Microsoft.AspNetCore.Mvc;
using Presentation_Layer.Models;

namespace REST.Controllers
{
    [ApiController]
    [Route("Fee")]
    public class FeeController: Controller
    {
        private readonly IFeeMiddlePoint feeMiddlePoint;
        private readonly IOneTimeFeeWebService oneTimeFeeWebService;
        private readonly IMonthlyFeeWebService monthlyFeeWebService;

        public FeeController(IFeeMiddlePoint feeMiddlePoint, IOneTimeFeeWebService oneTimeFeeWebService, IMonthlyFeeWebService monthlyFeeWebService)
        {
            this.feeMiddlePoint = feeMiddlePoint;
            this.oneTimeFeeWebService = oneTimeFeeWebService;
            this.monthlyFeeWebService = monthlyFeeWebService;
        }
        
        [HttpPost]
        [Route("OneTime")]
        public async Task<ActionResult<string>> OneTimeFeePaymentAsync([FromBody] UserCardInfo userCardInfo)
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
        public async Task<ActionResult<string>> MonthlyFeePaymentAsync([FromBody] UserCardInfo userCardInfo)
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
        public async Task<ActionResult<bool>> CheckSubscriptionAsync([FromQuery] string username)
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
        public async Task<ActionResult<IList<OneTimeFee>>> GetOneTimeFeeListAsync([FromQuery] string username)
        {
            try
            {
                IList<OneTimeFee> oneTimeFees = await oneTimeFeeWebService.GetOneTimeFeeListAsync(username);
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
        public async Task<ActionResult<IList<MonthlyFee>>> GetMonthlyFeeListAsync([FromQuery] string username)
        {
            try
            {
                IList<MonthlyFee> monthlyFees = await monthlyFeeWebService.GetMonthlyFeeListAsync(username);
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
        public async Task<ActionResult<MonthlyFee>> GetMonthlyFeeAsync([FromQuery] string username)
        {
            try
            {
                MonthlyFee monthlyFees = await monthlyFeeWebService.GetMonthlyFeeAsync(username);
                return Ok(monthlyFees);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        [Route("OneTime")]
        public async Task<ActionResult<OneTimeFee>> GetOneTimeFeeAsync([FromQuery] string username, int eventId)
        {
            try
            {
                OneTimeFee oneTimeFee = await oneTimeFeeWebService.GetOneTimeFeeAsync(username, eventId);
                return Ok(oneTimeFee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}