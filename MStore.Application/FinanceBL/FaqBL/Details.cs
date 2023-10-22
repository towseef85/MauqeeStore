using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.FaqDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.FaqBL
{
    public class Details
    {
        public class Query  : IRequest<ServiceStatus<GetFaqDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetFaqDto>>
        {
            private readonly IFaqRepository _iFaqRepo;
            public Handler(IFaqRepository iFaqRepo)
            {
                _iFaqRepo = iFaqRepo;
            }

            public async Task<ServiceStatus<GetFaqDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iFaqRepo.GetFaqById(request.Id);
                return result;

            }
        }
    }
}
