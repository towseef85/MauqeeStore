using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.TermAndConditionDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.TermAndConditionBL
{
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetTermAndConditionDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetTermAndConditionDto>>>
        {
            private readonly ITermAndConditionRepository _iTermAndConditionRepo;
            public Handler(ITermAndConditionRepository iTermAndConditionRepo)
            {
                _iTermAndConditionRepo = iTermAndConditionRepo;
            }
            public async Task<ServiceStatus<List<GetTermAndConditionDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iTermAndConditionRepo.GetAllTermAndCondition(request.SubscriptionId);
                return result;
            }
        }
    }
}
