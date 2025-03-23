using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.ProductQueries
{
    public record GetProductsByBrandQuery(string BrandName) : IRequest<IEnumerable<ProductEntity>>;

    public class GetProductsByBrandQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetProductsByBrandQuery, IEnumerable<ProductEntity>>
    {
        public async Task<IEnumerable<ProductEntity>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductsByBrandAsync(request.BrandName);
        }
    }
}
