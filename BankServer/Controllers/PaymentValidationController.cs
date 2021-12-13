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
        public ActionResult<string> ApprovePayment([FromBody] UserCardInfo userCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var message = paymentValidationMiddlePoint.ValidateCard(userCard);
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