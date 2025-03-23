using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.PaymentMethodCommands
{
    public record AddPaymentMethodCommand(PaymentMethodEntity paymentMethod) : IRequest<ResponseFormat<PaymentMethodEntity>>;


    public class AddPaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository)
        : IRequestHandler<AddPaymentMethodCommand, ResponseFormat<PaymentMethodEntity>>
    {
        public async Task<ResponseFormat<PaymentMethodEntity>> Handle(AddPaymentMethodCommand request, CancellationToken cancellationToken)
        {
            return await paymentMethodRepository.AddPaymentMethodAsync(request.paymentMethod);
        }
    }


}
