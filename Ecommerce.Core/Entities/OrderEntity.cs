

namespace Ecommerce.Core.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
    }
}
