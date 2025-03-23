using Ecommerce.Core.Formats;
using Ecommerce.Core.Interfaces;
using MediatR;

namespace Ecommerce.Application.Commands.PaymentMethodCommands
{
    public record DeletePaymentMethodCommand(Guid id) : IRequest<ResponseFormat<bool>>;

    public class DeletePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository)
        : IRequestHandler<DeletePaymentMethodCommand, ResponseFormat<bool>>
    {
        public async Task<ResponseFormat<bool>> Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            return await paymentMethodRepository.DeletePaymentMethodAsync(request.id);
        }
    }
}
