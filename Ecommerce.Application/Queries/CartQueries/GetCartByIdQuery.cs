using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.CartQueries
{
    public record GetCartByIdQuery(Guid CartId) : IRequest<CartEntity>;

    public class GetCartByIdQueryHandler(ICartRepository cartRepository)
        : IRequestHandler<GetCartByIdQuery, CartEntity>
    {
        public async Task<CartEntity> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            return await cartRepository.GetCartByIdAsync(request.CartId);
        }
    }
}
