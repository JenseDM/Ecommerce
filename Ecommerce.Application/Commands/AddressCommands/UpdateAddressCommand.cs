

using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.AddressCommands
{
    public record UpdateAddressCommand(AddressEntity address): IRequest<ResponseFormat<AddressEntity>>;

    public class UpdateAddressCommandHandler(IAddressRepository addressRepository)
        : IRequestHandler<UpdateAddressCommand, ResponseFormat<AddressEntity>>
    {
        public async Task<ResponseFormat<AddressEntity>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            return await addressRepository.UpdateAddressAsync(request.address);
        }
    }
}
