

namespace Ecommerce.Core.Entities
{
    public class CartEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CartItemEntity> CartItems { get; set; } = new List<CartItemEntity>();
    }
}
