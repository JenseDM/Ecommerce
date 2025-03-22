using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;


namespace Ecommerce.Application.Queries.UserQueries
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<UserEntity>>;

    public class GetAllUsersQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetAllUsersQuery, IEnumerable<UserEntity>>
    {
        public async Task<IEnumerable<UserEntity>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetAllUsersAsync();
        }
    }
}
