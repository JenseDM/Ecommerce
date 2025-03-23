using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Queries.PaymentMethodQueries
{
    public record GetPaymentMethodsByUserIdQuery(Guid UserId) : IRequest<IEnumerable<PaymentMethodEntity>>;

    public class GetPaymentMethodsByUserIdQueryhandler(IPaymentMethodRepository paymentMethodRepository)
        : IRequestHandler<GetPaymentMethodsByUserIdQuery, IEnumerable<PaymentMethodEntity>>
    {
        public async Task<IEnumerable<PaymentMethodEntity>> Handle(GetPaymentMethodsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await paymentMethodRepository.GetPaymentMethodsByUserIdAsync(request.UserId);
        }
    }
}
