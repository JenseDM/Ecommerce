using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Models;

namespace Ecommerce.Core.Interfaces
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItemDetailsModel>> GetCartItemsDetailAsync(Guid cartId);
        Task<CartItemEntity> GetCartItemByIdAsync(Guid cartItemId);
        Task<ResponseFormat<CartItemEntity>> AddCartItemAsync(CartItemEntity cartItem);
        Task<ResponseFormat<CartItemEntity>> UpdateCartItemAsync(CartItemEntity cartItem);
        Task<ResponseFormat<bool>> DeleteCartItemAsync(Guid cartItemId);

    }
}
