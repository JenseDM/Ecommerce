using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.UserQueries
{
    public record GetUserByEmailQuery(string Email) : IRequest<UserEntity>;

    public class GetUserByEmailQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetUserByEmailQuery, UserEntity>
    {
        public async Task<UserEntity> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUserByEmailAsync(request.Email);
        }
    }
}
