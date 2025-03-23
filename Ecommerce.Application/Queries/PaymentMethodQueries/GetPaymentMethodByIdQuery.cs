using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;


namespace Ecommerce.Application.Queries.PaymentMethodQueries
{
    public record GetPaymentMethodByIdQuery(Guid Id) : IRequest<PaymentMethodEntity>;

    public class GetPaymentMethodByIdQueryHandler(IPaymentMethodRepository paymentMethodRepository)
        : IRequestHandler<GetPaymentMethodByIdQuery, PaymentMethodEntity>
    {
        public async Task<PaymentMethodEntity> Handle(GetPaymentMethodByIdQuery request, CancellationToken cancellationToken)
        {
            return await paymentMethodRepository.GetPaymentMethodByIdAsync(request.Id);
        }
    }
}
