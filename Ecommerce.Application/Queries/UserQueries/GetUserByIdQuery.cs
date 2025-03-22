using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.UserQueries
{
    public record GetUserByIdQuery(Guid id) : IRequest<UserEntity>;

    public class GetUserByIdQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetUserByIdQuery, UserEntity>
    {
        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUserByIdAsync(request.id);
        }
    }
}
