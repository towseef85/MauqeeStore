using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.PaymentStatusDto;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.FinanceBL.PaymentStatusBL
{
    public class Details
    {
        public class Query : IRequest<ServiceStatus<GetPaymentStatusDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetPaymentStatusDto>>
        {
            private readonly IPaymentStatusRepository _iPaymentStatusRepo;
            public Handler(IPaymentStatusRepository iPaymentStatusRepo)
            {
                _iPaymentStatusRepo = iPaymentStatusRepo;
            }

            public async Task<ServiceStatus<GetPaymentStatusDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iPaymentStatusRepo.GetPaymentStatusById(request.Id);
            }
        }
    }
}
