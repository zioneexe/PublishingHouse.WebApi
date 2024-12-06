using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublishingHouse.Abstractions.Service;
using PublishingHouse.BLL.Service;
using PublishingHouse.WebApi.Dto.Request;

namespace PublishingHouse.WebApi.Controller
{

    [ApiController]
    [Route("api/payments")]
    [Authorize(Roles = "Admin, Customer")]
    public class PaymentController(IPaymentService paymentService) : ControllerBase
    {

        [HttpGet("total/{customerId:int:min(1)}")]
        public async Task<IActionResult> GetTotalAmount(int customerId)
        {
            try
            {
                var totalAmount = await paymentService.CalculateTotalAmountAsync(customerId);
                return Ok(totalAmount);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("initiate")]
        public async Task<IActionResult> InitiatePayment([FromBody] PaymentRequestDto paymentRequest)
        {
            try
            {
                if (!paymentService.ValidateCardNumber(paymentRequest.CardNumber))
                {
                    return BadRequest("Invalid card number.");
                }

                var expiryParts = paymentRequest.ExpiryDate.Split('/');
                if (expiryParts.Length != 2 ||
                    !int.TryParse(expiryParts[0], out var expMonth) ||
                    !int.TryParse(expiryParts[1], out var expYear))
                {
                    return BadRequest("Invalid expiry date format. Use MM/YY.");
                }

                var response = await paymentService.SendPaymentRequestAsync(
                    paymentRequest.Amount,
                    paymentRequest.CardNumber,
                    expMonth,
                    expYear,
                    paymentRequest.Cvv
                );

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
