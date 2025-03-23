using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;

namespace Ecommerce.Core.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethodEntity>> GetPaymentMethodsByUserIdAsync(Guid userId);
        Task<PaymentMethodEntity> GetPaymentMethodByIdAsync(Guid id);
        Task<ResponseFormat<PaymentMethodEntity>> AddPaymentMethodAsync(PaymentMethodEntity paymentMethod);
        Task<ResponseFormat<PaymentMethodEntity>> UpdatePaymentMethodAsync(PaymentMethodEntity paymentMethod);
        Task<ResponseFormat<bool>> DeletePaymentMethodAsync(Guid id);
    }
}
