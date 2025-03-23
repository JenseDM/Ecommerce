using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Queries.AddressQueries
{
    public record GetAddressesByUserIdQuery(Guid UserId) : IRequest<IEnumerable<AddressEntity>>;

    public class GetAddressesByUserIdQueryHandler(IAddressRepository addressRepository)
        : IRequestHandler<GetAddressesByUserIdQuery, IEnumerable<AddressEntity>>
    {
        public async Task<IEnumerable<AddressEntity>> Handle(GetAddressesByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await addressRepository.GetAddressesByUserIdAsync(request.UserId);
        }
    }
}
