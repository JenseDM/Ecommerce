using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.ProductCommands
{
    public record UpdateProductCommand(ProductEntity product) : IRequest<ResponseFormat<ProductEntity>>;

    public class UpdateProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<UpdateProductCommand, ResponseFormat<ProductEntity>>
    {
        public async Task<ResponseFormat<ProductEntity>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.UpdateProductAsync(request.product);
        }
    }
}
