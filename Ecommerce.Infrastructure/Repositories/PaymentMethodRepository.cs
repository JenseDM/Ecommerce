

using Ecommerce.Application.Queries.AddressQueries;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly AppDbContext _context;

        public PaymentMethodRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentMethodEntity>> GetPaymentMethodsByUserIdAsync(Guid userId)
        {
            if (_context.PaymentMethods == null)
            {
                throw new InvalidOperationException("No existe la tabla PaymentMethods.");
            }

            var PaymetMethods = await _context.PaymentMethods.Where(a => a.UserId == userId).ToListAsync();

            return PaymetMethods;
        }

        public async Task<PaymentMethodEntity> GetPaymentMethodByIdAsync(Guid id)
        {
            if (_context.PaymentMethods == null)
            {
                throw new InvalidOperationException("No existe la tabla PaymentMethods.");
            }
            var PaymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(a => a.Id == id);

            if (PaymentMethod == null)
            {
                throw new Exception("Método de pago no encontrado");
            }

            return PaymentMethod;
        }

        public async Task<ResponseFormat<PaymentMethodEntity>> AddPaymentMethodAsync(PaymentMethodEntity paymentMethod)
        {
            if (_context.PaymentMethods == null)
            {
                throw new InvalidOperationException("No existe la tabla PaymentMethods.");
            }
            await _context.PaymentMethods.AddAsync(paymentMethod);
            await _context.SaveChangesAsync();
            var response = new ResponseFormat<PaymentMethodEntity>
            {
                Success = true,
                Message = "Método de pago agregado correctamente",
                Data = paymentMethod
            };
            return response;
        }

        public async Task<ResponseFormat<PaymentMethodEntity>> UpdatePaymentMethodAsync(PaymentMethodEntity paymentMethod)
        {
            if (_context.PaymentMethods == null)
            {
                throw new InvalidOperationException("No existe la tabla PaymentMethods.");
            }
            var paymentMethodToUpdate = await _context.PaymentMethods.FirstOrDefaultAsync(a => a.Id == paymentMethod.Id);
            if (paymentMethodToUpdate == null)
            {
                throw new Exception("Método de pago no encontrado");
            }
            paymentMethodToUpdate.CardNumber = paymentMethod.CardNumber;
            paymentMethodToUpdate.ExpiryDate = paymentMethod.ExpiryDate;
            paymentMethodToUpdate.CVV = paymentMethod.CVV;
            paymentMethodToUpdate.CardHolderName = paymentMethod.CardHolderName;
            _context.PaymentMethods.Update(paymentMethodToUpdate);
            await _context.SaveChangesAsync();
            var response = new ResponseFormat<PaymentMethodEntity>
            {
                Success = true,
                Message = "Método de pago actualizado correctamente",
                Data = paymentMethodToUpdate
            };
            return response;
        }

        public async Task<ResponseFormat<bool>> DeletePaymentMethodAsync(Guid id)
        {
            if (_context.PaymentMethods == null)
            {
                throw new InvalidOperationException("No existe la tabla PaymentMethods.");
            }
            var paymentMethodToDelete = await _context.PaymentMethods.FirstOrDefaultAsync(a => a.Id == id);
            if (paymentMethodToDelete == null)
            {
                throw new Exception("Método de pago no encontrado");
            }
            _context.PaymentMethods.Remove(paymentMethodToDelete);
            await _context.SaveChangesAsync();
            var response = new ResponseFormat<bool>
            {
                Success = true,
                Message = "Método de pago eliminado correctamente",
                Data = true
            };
            return response;
        }
    }
}
