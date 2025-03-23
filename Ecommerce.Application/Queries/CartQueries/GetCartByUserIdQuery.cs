using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.CartQueries
{
    public record GetCartByUserIdQuery(Guid UserId) : IRequest<CartEntity>;

    public class GetCartByUserIdQueryHandler(ICartRepository cartRepository)
        : IRequestHandler<GetCartByUserIdQuery, CartEntity>
    {
        public async Task<CartEntity> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await cartRepository.GetCartByUserIdAsync(request.UserId);
        }
    }
}
