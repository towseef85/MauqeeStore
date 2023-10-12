using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CurrencyDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.CurrencyBL
{
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetCurrencyDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetCurrencyDto>>>
        {
            private readonly ICurrencyRepository _iCurrencyRepo;
            public Handler(ICurrencyRepository iCurrencyRepo)
            {
                _iCurrencyRepo = iCurrencyRepo;
            }
            public async Task<ServiceStatus<List<GetCurrencyDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iCurrencyRepo.GetAllCurrency(request.SubscriptionId);

            }
        }
    }
}
