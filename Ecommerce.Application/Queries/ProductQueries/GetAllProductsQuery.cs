using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.ProductQueries
{
    public record GetAllProductsQuery() : IRequest<IEnumerable<ProductEntity>>;

    public class GetAllProductsQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductEntity>>
    {
        public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetAllProductsAsync();
        }
    }

}
