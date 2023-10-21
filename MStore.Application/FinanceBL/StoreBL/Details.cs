using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.StoreDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.StoreBL
{
    public class Details
    {
        public class Query  : IRequest<ServiceStatus<GetStoreDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetStoreDto>>
        {
            private readonly IStoreRepository _iStoreRepo;
            public Handler(IStoreRepository iStoreRepo)
            {
                _iStoreRepo = iStoreRepo;
            }

            public async Task<ServiceStatus<GetStoreDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iStoreRepo.GetStoreById(request.Id);
                return result;

            }
        }
    }
}
