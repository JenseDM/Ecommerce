using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.ProductQueries
{
    public record GetProductByIdQuery(Guid Id) : IRequest<ProductEntity>;

    public class GetProductByIdQueryHanlder(IProductRepository productRepository)
        : IRequestHandler<GetProductByIdQuery, ProductEntity>
    {
        public async Task<ProductEntity> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductByIdAsync(request.Id);
        }
    }

}
