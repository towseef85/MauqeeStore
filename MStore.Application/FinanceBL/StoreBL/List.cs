using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.StoreDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.StoreBL
{
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetStoreDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetStoreDto>>>
        {
            private readonly IStoreRepository _iStoreRepo;
            public Handler(IStoreRepository iStoreRepo)
            {
                _iStoreRepo = iStoreRepo;
            }
            public async Task<ServiceStatus<List<GetStoreDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iStoreRepo.GetAllStore(request.SubscriptionId);
                return result;
            }
        }
    }
}
