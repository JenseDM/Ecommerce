using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.ProductQueries
{
    public record GetProductsByPriceQuery(decimal Price) : IRequest<IEnumerable<ProductEntity>>;

    public class GetProductsByPriceQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetProductsByPriceQuery, IEnumerable<ProductEntity>>
    {
        public async Task<IEnumerable<ProductEntity>> Handle(GetProductsByPriceQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductsByPriceAsync(request.Price);
        }
    }
}
