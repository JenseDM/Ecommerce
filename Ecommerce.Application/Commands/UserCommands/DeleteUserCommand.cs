using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.UserCommands
{
    public record DeleteUserCommand(Guid Id) : IRequest<ResponseFormat<bool>>;

    public class DeleteUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<DeleteUserCommand, ResponseFormat<bool>>
    {
        public async Task<ResponseFormat<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.DeleteUserAsync(request.Id);
        }
    }
}
