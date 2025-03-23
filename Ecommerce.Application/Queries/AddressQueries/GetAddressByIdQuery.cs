using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.AddressQueries
{
    public record GetAddressByIdQuery(Guid AddressId) : IRequest<AddressEntity>;

    public class  GetAddressByIdQueryHandler(IAddressRepository addressRepository)
    {
        public async Task<AddressEntity> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            return await addressRepository.GetAddressByIdAsync(request.AddressId);
        }
    }
}
