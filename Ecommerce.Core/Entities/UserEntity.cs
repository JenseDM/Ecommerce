using Ecommerce.Core.Enums;

namespace Ecommerce.Core.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public RoleEnum Role { get; set; } = RoleEnum.user;
        public string ImageUrl {  get; set; } = string.Empty;
        public ICollection<AddressEntity> Addresses { get; set; } = new List<AddressEntity>();
        public ICollection<PaymentMethodEntity> paymentMethodEntities { get; set; } = new List<PaymentMethodEntity>();
        public CartEntity Cart { get; set; } = new CartEntity();
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
        public ICollection<ProductEntity> FavoriteProducts { get; set; } = new List<ProductEntity>();
    }


}
