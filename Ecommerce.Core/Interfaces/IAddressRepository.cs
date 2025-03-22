
using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;

namespace Ecommerce.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<ResponseFormat<AddressEntity>> AddAddressAsync(AddressEntity address, Guid userId);
        Task<ResponseFormat<AddressEntity>> UpdateAddressAsync(AddressEntity address);
        Task<ResponseFormat<bool>> DeleteAddressAsync(Guid addressId);
        Task<AddressEntity> GetAddressByIdAsync(Guid addressId);
        Task<IEnumerable<AddressEntity>> GetAddressesByUserIdAsync(Guid userId);

    }
}
