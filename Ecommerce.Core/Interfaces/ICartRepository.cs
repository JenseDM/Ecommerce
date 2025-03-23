
using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;

namespace Ecommerce.Core.Interfaces
{
    public interface ICartRepository
    {
        Task<CartEntity> GetCartByUserIdAsync(Guid userId);
        Task<CartEntity> GetCartByIdAsync(Guid cartId);
        Task<ResponseFormat<CartEntity>> AddCartAsync(Guid userId);
    }
}
