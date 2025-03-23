

namespace Ecommerce.Core.Entities
{
    public class AddressEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}
