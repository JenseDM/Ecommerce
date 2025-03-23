using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.CartItemCommands
{
    public record UpdateCartItemCommand(CartItemEntity CartItem) : IRequest<ResponseFormat<CartItemEntity>>;

    public class UpdateCartItemCommandHandler(ICartItemRepository cartItemRepository)
        : IRequestHandler<UpdateCartItemCommand, ResponseFormat<CartItemEntity>>
    {
        public async Task<ResponseFormat<CartItemEntity>> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            return await cartItemRepository.UpdateCartItemAsync(request.CartItem);
        }
    }
    
}
