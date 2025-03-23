using Ecommerce.Core.Entities;
using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.PaymentMethodCommands
{
    public record UpdatePaymentMethodCommand(PaymentMethodEntity paymentMethod) : IRequest<ResponseFormat<PaymentMethodEntity>>;

    public class UpdatePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository)
        : IRequestHandler<UpdatePaymentMethodCommand, ResponseFormat<PaymentMethodEntity>>
    {
        public async Task<ResponseFormat<PaymentMethodEntity>> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            return await paymentMethodRepository.UpdatePaymentMethodAsync(request.paymentMethod);
        }
    }

}
