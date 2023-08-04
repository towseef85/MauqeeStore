using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.SubscriptionDtos;
using MStore.Application.Interfaces;

namespace MStore.Application.IdentityBL.SubscriptionBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetSubscriptionDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetSubscriptionDto>>>
        {
            private readonly ISubscriptionRepository _iSubscriptionRepo;
            public Handler(ISubscriptionRepository iSubscriptionRepo)
            {
                _iSubscriptionRepo = iSubscriptionRepo;
            }
            public async Task<Result<List<GetSubscriptionDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iSubscriptionRepo.GetAllSubscription();
                return Result<List<GetSubscriptionDto>>.Success(result);
            }
        }
    }
}
