

using Ecommerce.Core.Entities;
using Ecommerce.Core.Enums;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.ProductQueries
{
    public record GetProductsByCategoryQuery(CategoryProductEnum CategoryProductEnum) : IRequest<IEnumerable<ProductEntity>>;

    public class GetProductsByCategoryQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetProductsByCategoryQuery, IEnumerable<ProductEntity>>
    {
        public async Task<IEnumerable<ProductEntity>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductsByCategoryAsync(request.CategoryProductEnum);
        }
    }
}
