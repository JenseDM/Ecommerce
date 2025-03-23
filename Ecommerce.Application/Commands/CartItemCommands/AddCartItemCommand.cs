using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.CartItemCommands
{
    public record AddCartItemCommand(CartItemEntity CartItem) : IRequest<ResponseFormat<CartItemEntity>>;

    public class AddCartItemCommandHandler(ICartItemRepository cartItemRepository)
        : IRequestHandler<AddCartItemCommand, ResponseFormat<CartItemEntity>>
    {
        public async Task<ResponseFormat<CartItemEntity>> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            return await cartItemRepository.AddCartItemAsync(request.CartItem);
        }
    }
}
