using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.CartItemCommands
{
    public record DeleteCartItemCommand(Guid CartItemId) : IRequest<ResponseFormat<bool>>;

    public class DeleteCartItemCommandHandler(ICartItemRepository cartItemRepository)
        : IRequestHandler<DeleteCartItemCommand, ResponseFormat<bool>>
    {
        public async Task<ResponseFormat<bool>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            return await cartItemRepository.DeleteCartItemAsync(request.CartItemId);
        }
    }
}
