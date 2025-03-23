

using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.ProductCommands
{
    public record AddProductCommand(ProductEntity product) : IRequest<ResponseFormat<ProductEntity>>;

    public class AddProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<AddProductCommand, ResponseFormat<ProductEntity>>
    {
        public async Task<ResponseFormat<ProductEntity>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.AddProductAsync(request.product);
        }
    }
}
