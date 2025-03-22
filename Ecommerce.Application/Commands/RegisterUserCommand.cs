using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;


namespace Ecommerce.Application.Commands
{
    public record RegisterUserCommand(UserEntity user) : IRequest<ResponseFormat<Guid>>;

    public class RegisterUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<RegisterUserCommand, ResponseFormat<Guid>>
    {
        public async Task<ResponseFormat<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.RegisterAsync(request.user);
        }
    }
}
