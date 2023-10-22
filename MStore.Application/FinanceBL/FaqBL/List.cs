using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.FaqDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.FaqBL
{
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetFaqDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetFaqDto>>>
        {
            private readonly IFaqRepository _iFaqRepo;
            public Handler(IFaqRepository iFaqRepo)
            {
                _iFaqRepo = iFaqRepo;
            }
            public async Task<ServiceStatus<List<GetFaqDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iFaqRepo.GetAllFaq(request.SubscriptionId);
                return result;
            }
        }
    }
}
