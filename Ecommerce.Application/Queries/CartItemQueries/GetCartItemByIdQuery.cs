using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.CartItemQueries
{
    public record GetCartItemByIdQuery(Guid CartItemId) : IRequest<CartItemEntity>;

    public class GetCartItemByIdQueryHandler(ICartItemRepository cartItemRepository)
        : IRequestHandler<GetCartItemByIdQuery, CartItemEntity>
    {
        public async Task<CartItemEntity> Handle(GetCartItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await cartItemRepository.GetCartItemByIdAsync(request.CartItemId);
        }
    }
}
