using Ecommerce.Application.Commands.CartCommands;
using Ecommerce.Application.Queries.CartQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(ISender sender) : ControllerBase
    {

        [HttpGet("GetCartById/{id}")]
        public async Task<IActionResult> GetCartByIdAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new GetCartByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetCartByUserId/{userId}")]
        public async Task<IActionResult> GetCartByUserIdAsync([FromRoute] Guid userId)
        {
            var result = await sender.Send(new GetCartByUserIdQuery(userId));
            return Ok(result);
        }

        [HttpPost("AddCart/{userId}")]
        public async Task<IActionResult> AddCartAsync([FromRoute] Guid userId)
        {
            var result = await sender.Send(new AddCartCommand(userId));
            return Ok(result);
        }
    }
}
