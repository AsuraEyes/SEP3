using System;
using System.Threading.Tasks;
using BankServer.MiddlePoint;
using Microsoft.AspNetCore.Mvc;
using Presentation_Layer.Models;

namespace BankServer.Controllers
{
    [ApiController]
    [Route ("PaymentValidation")]
    public class PaymentValidationController : Controller
    {
        private IPaymentValidationMiddlePoint paymentValidationMiddlePoint;
        public PaymentValidationController(IPaymentValidationMiddlePoint paymentValidationMiddlePoint)
        {
            this.paymentValidationMiddlePoint = paymentValidationMiddlePoint;
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> ApprovePaymentAsync([FromBody] UserCardInfo userCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var message = await paymentValidationMiddlePoint.ValidateCard(userCard);
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