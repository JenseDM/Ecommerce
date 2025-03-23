using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.AddressCommands
{
    public record DeleteAddressCommand(Guid addressId) : IRequest<ResponseFormat<bool>>;

    public class DeleteAddressCommandHandler(IAddressRepository addressRepository)
        : IRequestHandler<DeleteAddressCommand, ResponseFormat<bool>>
    {
        public async Task<ResponseFormat<bool>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            return await addressRepository.DeleteAddressAsync(request.addressId);
        }
    }
}
