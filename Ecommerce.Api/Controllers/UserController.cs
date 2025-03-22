using Ecommerce.Application.Commands.UserCommands;
using Ecommerce.Application.Queries.UserQueries;
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

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await sender.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute]Guid id)
        {
            var result = await sender.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmailAsync([FromRoute]string email)
        {
            var result = await sender.Send(new GetUserByEmailQuery(email));
            return Ok(result);
        }

        [HttpPut("UpdateBasicUser")]
        public async Task<IActionResult> UpdateBasicUserAsync([FromBody] UserEntity user)
        {
            var result = await sender.Send(new UpdateUserBasicCommand(user));
            return Ok(result);
        }

        [HttpPut("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid id)
        {
            var result = await sender.Send(new DeleteUserCommand(id));
            return Ok(result);
        }
    }
}
