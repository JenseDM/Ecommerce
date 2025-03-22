using Ecommerce.Core.Enums;

namespace Ecommerce.Core.Entities
{
    public class PaymentMethodEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public DateOnly ExpiryDate { get; set; }
        public string CVV { get; set; } = null!;
        public string CardHolderName { get; set; } = string.Empty;
        public PaymentCardTypeEnum PaymentMethod { get; set; }
        public PaymentCardProviderEnum PaymentProvider { get; set; }
    }
}
