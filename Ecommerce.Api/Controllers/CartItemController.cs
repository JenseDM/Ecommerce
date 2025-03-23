using Ecommerce.Application.Commands.CartItemCommands;
using Ecommerce.Application.Queries.CartItemQueries;
using Ecommerce.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController(ISender sender) : ControllerBase
    {
        [HttpGet("GetCartItemsDetail/{cartId}")]
        public async Task<IActionResult> GetCartItemsDetailAsync([FromRoute]Guid cartId)
        {
            var result = await sender.Send(new GetCartItemsDetailQuery(cartId));
            return Ok(result);
        }

        [HttpGet("GetCartItemById/{cartItemId}")]
        public async Task<IActionResult> GetCartItemByIdAsync([FromRoute] Guid cartItemId)
        {
            var result = await sender.Send(new GetCartItemByIdQuery(cartItemId));
            return Ok(result);
        }

        [HttpPost("AddCartItem")]
        public async Task<IActionResult> AddCartItemAsync([FromBody] CartItemEntity cartItem)
        {
            var result = await sender.Send(new AddCartItemCommand(cartItem));
            return Ok(result);
        }

        [HttpPut("UpdateCartItem")]
        public async Task<IActionResult> UpdateCartItemAsync([FromBody] CartItemEntity cartItem)
        {
            var result = await sender.Send(new UpdateCartItemCommand(cartItem));
            return Ok(result);
        }

        [HttpDelete("DeleteCartItem/{cartItemId}")]
        public async Task<IActionResult> DeleteCartItemAsync([FromRoute] Guid cartItemId)
        {
            var result = await sender.Send(new DeleteCartItemCommand(cartItemId));
            return Ok(result);
        }
    }

}
