using Ecommerce.Core.Interfaces;
using Ecommerce.Core.Models;
using MediatR;

namespace Ecommerce.Application.Queries.CartItemQueries
{
    public record GetCartItemsDetailQuery(Guid CartId) : IRequest<IEnumerable<CartItemDetailsModel>>;

    public class GetCartItemsDetailQueryHandler(ICartItemRepository cartItemRepository)
        : IRequestHandler<GetCartItemsDetailQuery, IEnumerable<CartItemDetailsModel>>
    {
        public async Task<IEnumerable<CartItemDetailsModel>> Handle(GetCartItemsDetailQuery request, CancellationToken cancellationToken)
        {
            return await cartItemRepository.GetCartItemsDetailAsync(request.CartId);
        }
    }
}
