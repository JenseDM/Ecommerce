using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.CartCommands
{
    public record AddCartCommand(Guid UserId) : IRequest<ResponseFormat<CartEntity>>;

    public class AddCartCommandHandler(ICartRepository cartRepository)
        : IRequestHandler<AddCartCommand, ResponseFormat<CartEntity>>
    {
        public async Task<ResponseFormat<CartEntity>> Handle(AddCartCommand request, CancellationToken cancellationToken)
        {
            return await cartRepository.AddCartAsync(request.UserId);
        }
    }
}
