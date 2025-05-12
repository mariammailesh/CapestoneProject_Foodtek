using CapestoneProject.DTOs.PaymentCardDTO.Request;
using CapestoneProject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCardController : ControllerBase
    {
        IPaymentCardService _paymentCardService;
        public PaymentCardController(IPaymentCardService paymentCardService)
        {
            _paymentCardService = paymentCardService;
        }
        /// <summary>
        /// Add Payment Card, each user can have multiple payment cards
        /// </summary>
        [HttpPost("[action]")]
        public async Task<IActionResult> AddPaymentCardAsync(PaymentCardInputDTO input)
        {
            try
            {
                if (input == null)
                    return BadRequest("Invalid input data");
                bool result = await _paymentCardService.AddPaymentCardAsync(input);
                if (result)
                    return Ok("Payment card added successfully");
                else
                    return BadRequest("Failed to add payment card");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
