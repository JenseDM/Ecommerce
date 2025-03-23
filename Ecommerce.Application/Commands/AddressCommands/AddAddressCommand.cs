using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.AddressCommands
{
     public record AddAddressCommand(AddressEntity address): IRequest<ResponseFormat<AddressEntity>>;

    public class AddAddressCommandHandler(IAddressRepository addressRepository)
        : IRequestHandler<AddAddressCommand, ResponseFormat<AddressEntity>>
    {
        public async Task<ResponseFormat<AddressEntity>> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            return await addressRepository.AddAddressAsync(request.address);
        }
    }
}
