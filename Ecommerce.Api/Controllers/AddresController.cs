using Ecommerce.Application.Commands.AddressCommands;
using Ecommerce.Application.Queries.AddressQueries;
using Ecommerce.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddresController(ISender sender) : ControllerBase
    {
        [HttpGet("GetAddressById/{id}")]
        public async Task<IActionResult> GetAddressByIdAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new GetAddressByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetAddressesByUserId/{userId}")]
        public async Task<IActionResult> GetAddressesByUserIdAsync([FromRoute] Guid userId)
        {
            var result = await sender.Send(new GetAddressesByUserIdQuery(userId));
            return Ok(result);
        }

        [HttpPost("AddAddress/{userId}")]
        public async Task<IActionResult> AddAddressAsync([FromBody] AddressEntity address, [FromRoute] Guid userId)
        {
            var result = await sender.Send(new AddAddressCommand(address, userId));
            return Ok(result);
        }

        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddressAsync([FromBody] AddressEntity address)
        {
            var result = await sender.Send(new UpdateAddressCommand(address));
            return Ok(result);
        }

        [HttpDelete("DeleteAddress/{id}")]
        public async Task<IActionResult> DeleteAddressAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new DeleteAddressCommand(id));
            return Ok(result);
        }
    }
}
