using Ecommerce.Core.Formats;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.UserCommands
{
    public record UpdateUserBasicCommand(UserEntity User) : IRequest<ResponseFormat<UserEntity>>;

    public class UpdateUserBasicCommandHandler(IUserRepository userRepository)
        : IRequestHandler<UpdateUserBasicCommand, ResponseFormat<UserEntity>>
    {
        public async Task<ResponseFormat<UserEntity>> Handle(UpdateUserBasicCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.UpdateUserBasicAsync(request.User);
        }
    }
}
