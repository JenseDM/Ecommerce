using Ecommerce.Application.Commands.PaymentMethodCommands;
using Ecommerce.Application.Queries.PaymentMethodQueries;
using Ecommerce.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController(ISender sender) : ControllerBase
    {
        [HttpGet("GetPaymentMethodById/{id}")]
        public async Task<IActionResult> GetPaymentMethodByIdAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new GetPaymentMethodByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetPaymentMethodsByUserId/{userId}")]
        public async Task<IActionResult> GetPaymentMethodsByUserIdAsync([FromRoute] Guid userId)
        {
            var result = await sender.Send(new GetPaymentMethodsByUserIdQuery(userId));
            return Ok(result);
        }

        [HttpPost("AddPaymentMethod")]
        public async Task<IActionResult> AddPaymentMethodAsync([FromBody] PaymentMethodEntity paymentMethod)
        {
            var result = await sender.Send(new AddPaymentMethodCommand(paymentMethod));
            return Ok(result);
        }

        [HttpPut("UpdatePaymentMethod")]
        public async Task<IActionResult> UpdatePaymentMethodAsync([FromBody] PaymentMethodEntity paymentMethod)
        {
            var result = await sender.Send(new UpdatePaymentMethodCommand(paymentMethod));
            return Ok(result);
        }

        [HttpDelete("DeletePaymentMethod/{id}")]
        public async Task<IActionResult> DeletePaymentMethodAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new DeletePaymentMethodCommand(id));
            return Ok(result);
        }
    }
}
