using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.MarketingDto.AffiliateDto;
using MStore.Application.Interfaces;

namespace MStore.Application.MarketingBL.AffiliateBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetAffiliateDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetAffiliateDto>>>
        {
            private readonly IAffiliateRepository _iAffiliateRepo;
            public Handler(IAffiliateRepository iAffiliateRepo)
            {
                _iAffiliateRepo = iAffiliateRepo;
            }
            public async Task<Result<List<GetAffiliateDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iAffiliateRepo.GetAllAffiliate(request.SubscriptionId);
                return Result<List<GetAffiliateDto>>.Success(result);
            }
        }
    }
}
