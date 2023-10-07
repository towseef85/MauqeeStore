using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.PaymentStatusDto;
using MStore.Application.Interfaces;


namespace MStore.Application.FinanceBL.PaymentStatusBL
{
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetPaymentStatusDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetPaymentStatusDto>>>
        {
            private readonly IPaymentStatusRepository _iPaymentStatusRepo;
            public Handler(IPaymentStatusRepository iPaymentStatusRepo)
            {
                _iPaymentStatusRepo = iPaymentStatusRepo;
            }
            public async Task<ServiceStatus<List<GetPaymentStatusDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iPaymentStatusRepo.GetAllPaymentStatus(request.SubscriptionId);

            }
        }
    }
}
