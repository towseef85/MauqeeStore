using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.TermAndConditionDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.TermAndConditionBL
{
    public class Details
    {
        public class Query  : IRequest<ServiceStatus<GetTermAndConditionDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetTermAndConditionDto>>
        {
            private readonly ITermAndConditionRepository _iTermAndConditionRepo;
            public Handler(ITermAndConditionRepository iTermAndConditionRepo)
            {
                _iTermAndConditionRepo = iTermAndConditionRepo;
            }

            public async Task<ServiceStatus<GetTermAndConditionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iTermAndConditionRepo.GetTermAndConditionById(request.Id);
                return result;

            }
        }
    }
}
