using System;
using System.Threading.Tasks;
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

        public FeeController(IFeeMiddlePoint feeMiddlePoint, IOneTimeFeeWebService oneTimeFeeWebService)
        {
            this.feeMiddlePoint = feeMiddlePoint;
            this.oneTimeFeeWebService = oneTimeFeeWebService;
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
        [Route("Subscription")]
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
    }
}