using Ecommerce.Application.Commands;
using Ecommerce.Application.Queries;
using Ecommerce.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ISender sender) : ControllerBase
    {
        [HttpPost("AddUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserEntity user)
        {
            var result = await sender.Send(new RegisterUserCommand(user));
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(string email, string password)
        {
            var result = await sender.Send(new LoginUserQuery(email, password));
            return Ok(result);
        }
    }
}
