using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.ProductCommands
{
    public record DeleteProductCommand(Guid id) : IRequest<ResponseFormat<bool>>;

    public class DeleteProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<DeleteProductCommand, ResponseFormat<bool>>
    {
        public async Task<ResponseFormat<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.DeleteProductAsync(request.id);
        }
    }
}
